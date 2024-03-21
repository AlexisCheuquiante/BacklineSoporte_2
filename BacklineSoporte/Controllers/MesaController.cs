using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class MesaController : Controller
    {
        // GET: Mesa
        public ActionResult Index(string limpiar, string buscar)
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "LoginCliente");
            }
            Models.RequerimientoModel modelo = new Models.RequerimientoModel();
            Entity.Filtro filtro = new Entity.Filtro();
            if (limpiar != null)
            {
                var text = DateTime.Now.ToString();
                Session["FechaActual"] = text;
                filtro.EmpId = SessionH.Usuario.Emp_Id;
                modelo.ListaRequerimiento = DAL.RequerimientoDAL.ObtenerRequerimientoVisible(filtro);
                Session["registrosEncontrados"] = modelo.ListaRequerimiento;
            }
            if (buscar != null)
            {
                Session["FiltroInformeDesde"] = Session["FiltroInformeDesde"];
                Session["FiltroInformeHasta"] = Session["FiltroInformeHasta"];
                modelo.ListaRequerimiento = Session["registrosEncontrados"] as List<Entity.Requerimiento>;
            }

            return View(modelo);
        }
        public JsonResult InsertarApruebo(int id)
        {
            try
            {
                BacklineSoporte.DAL.RequerimientoDAL.InsertarApruebo(id);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public JsonResult InsertarDesapruebo(int id)
        {
            try
            {
                BacklineSoporte.DAL.RequerimientoDAL.InsertarDesapruebo(id);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public ActionResult BusquedaFiltro(Entity.Filtro entity)
        {
            Session["numero_Buscado"] = null;

            entity.FechaDesde = Utiles.FechaObtenerMinimo(entity.FechaDesde);
            entity.FechaHasta = Utiles.FechaObtenerMaximo(entity.FechaHasta);
            entity.EmpId = SessionH.Usuario.Emp_Id;
            if (entity.Estado != 7 && entity.Estado != 1)
            {
                entity.Estado = 0;
            }
            List<Entity.Requerimiento> historicosEncontrados = DAL.RequerimientoDAL.ObtenerRequerimiento(entity);
            Session["FiltroInformeDesde"] = Utiles.ReversaFecha(entity.FechaDesde);
            Session["FiltroInformeHasta"] = Utiles.ReversaFecha(entity.FechaHasta);
            Session["registrosEncontrados"] = historicosEncontrados;
           
            if (entity.Estado == 7 || entity.Estado == 1)
            {
                Session["FiltroEstado"] = entity.Estado;
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult ObtenerRequerimiento_Numero(Entity.Filtro entity)
        {
            if (entity.Id <= 0)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "errorNumero", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            List<Entity.Requerimiento> historicosEncontrados = DAL.RequerimientoDAL.ObtenerRequerimiento_Numero(entity);
            Session["numero_Buscado"] = entity.Id;
            Session["registrosEncontrados"] = historicosEncontrados;

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public FileContentResult ExportToExcel()
        {
            var timestamp = Utiles.ObtenerTimeStamp();

            List<Entity.Requerimiento> lista = Session["registrosEncontrados"] as List<Entity.Requerimiento>;

            if (lista != null && lista.Count > 0)
            {
                string[] columns = { "Numero", "Funcionalidad", "Detalle", "Solicitante", "Ingreso", "Termino", "Estado_Requerimiento", "Empresa" };
                byte[] filecontent = Code.ExcelExportHelper.ExportExcel(lista, "Requerimientos", true, columns);
                return File(filecontent, Code.ExcelExportHelper.ExcelContentType, "Requerimientos" + "_" + SessionH.Usuario.Empresa + "(" + timestamp + ")" + ".xlsx");
            }
            else
            {
                return null;
            }

        }
    }
}