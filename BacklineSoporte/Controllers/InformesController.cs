using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;
using System.Configuration;

namespace BacklineSoporte.Controllers
{
    public class InformesController : Controller
    {
        // GET: Informes
        public ActionResult Index(string buscar, string limpiar)
        {
            Models.InformesModel modelo = new Models.InformesModel();
            if (buscar != null)
            {
                modelo.Lista = Session["RegistrosEncontrados"] as List<Entity.InformesConsolidados>;
            }
            if (limpiar != null)
            {
                Session["registrosEncontrados"] = null;

                List<Entity.InformesConsolidados> lista = new List<Entity.InformesConsolidados>();
                modelo.Lista = lista;
            }
            
            return View(modelo);
        }
        public JsonResult ObtenerTipoBusqueda()
        {
            var lista = DAL.TipoBusquedaDAL.ObtenerTipoBusqueda();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerEmpresas()
        {
            var lista = DAL.EmpresaDAL.ObtenerEmpresas();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerBodegas(Entity.Filtro entity)
        {
            if (entity.EmpId <= 0)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            var lista = DAL.BodegaDAL.ObtenerBodegas(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult BusquedaFiltro(Entity.Filtro entity)
        {
            Session["RegistrosEncontrados"] = null;

            if (entity.TipoBusqueda_Id == 1)
            {
                List<Entity.InformesConsolidados> historicosEncontrados = DAL.InformesConsolidadosDAL.ObtenerConsolidadoEmpresa(entity);
                Session["RegistrosEncontrados"] = historicosEncontrados;
            }
            if (entity.TipoBusqueda_Id == 2)
            {
                List<Entity.InformesConsolidados> historicosEncontrados = DAL.InformesConsolidadosDAL.ObtenerConsolidadoBodega(entity);
                Session["RegistrosEncontrados"] = historicosEncontrados;
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public FileContentResult ExportToExcel()
        {
            var timestamp = Utiles.ObtenerTimeStamp();
            List<Entity.InformesConsolidados> lista = Session["registrosEncontrados"] as List<Entity.InformesConsolidados>;

            var nombreEmpresa = lista[0].Empresa;
            var titulo = lista[0].TituloInforme;

            if (lista != null && lista.Count > 0)
            {
                string[] columns = { "Id_Producto", "CodigoBarra", "DescripcionProducto", "Stock", "Bodega" };
                byte[] filecontent = Code.ExcelExportHelper.ExportExcel(lista, "Informe_Consolidado", true, columns);
                return File(filecontent, Code.ExcelExportHelper.ExcelContentType, titulo + "_" + nombreEmpresa + "(" + timestamp + ")" + ".xlsx");
            }
            else
            {
                return null;
            }

        }
    }
}