using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class PanelHorasController : Controller
    {
        // GET: PanelHoras
        public ActionResult Index(string limpiar, string buscar)
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Models.PanelHorasModel modelo = new Models.PanelHorasModel();
            Entity.Filtro filtro = new Entity.Filtro();
            if (limpiar != null)
            {
                Session["RegistrosEncontrados"] = null;
                List<Entity.HorasDesarrollo> lista = new List<Entity.HorasDesarrollo>();
                modelo.listaHoras = lista;
            }
            if (buscar != null)
            {
                Session["FiltroInformeDesde"] = Session["FiltroInformeDesde"];
                Session["FiltroInformeHasta"] = Session["FiltroInformeHasta"];
                modelo.listaHoras = Session["RegistrosEncontrados"] as List<Entity.HorasDesarrollo>;
            }
            return View(modelo);
        }
        public ActionResult BusquedaFiltro(Entity.Filtro entity)
        {
            
            entity.FechaDesde = Utiles.FechaObtenerMinimo(entity.FechaDesde);
            entity.FechaHasta = Utiles.FechaObtenerMaximo(entity.FechaHasta);
            List<Entity.HorasDesarrollo> historicosEncontrados = DAL.HorasDesarrolloDAL.ObtenerHorasDesarollo(entity);
            Session["FiltroInformeDesde"] = Utiles.ReversaFecha(entity.FechaDesde);
            Session["FiltroInformeHasta"] = Utiles.ReversaFecha(entity.FechaHasta);
            Session["RegistrosEncontrados"] = historicosEncontrados;

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public FileContentResult ExportToExcel()
        {
            var timestamp = Utiles.ObtenerTimeStamp();

            List<Entity.HorasDesarrollo> lista = Session["registrosEncontrados"] as List<Entity.HorasDesarrollo>;

            if (lista != null && lista.Count > 0)
            {
                string[] columns = { "Desarrollo", "Fecha", "HoraInicio", "HoraTermino", "Total_Trabajado", "Observacion", "Desarrollador", "Estado" };
                byte[] filecontent = Code.ExcelExportHelper.ExportExcel(lista, "Horas", true, columns);
                return File(filecontent, Code.ExcelExportHelper.ExcelContentType, "Horas_Trabajas_De_" + "_" + SessionH.Usuario.NombreCompleto + "(" + timestamp + ")" + ".xlsx");
            }
            else
            {
                return null;
            }

        }
    }
}