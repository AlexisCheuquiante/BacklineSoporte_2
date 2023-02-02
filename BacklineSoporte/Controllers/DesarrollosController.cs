using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class DesarrollosController : Controller
    {
        // GET: Desarrollos
        public ActionResult Index(string buscar, string limpiar)
        {
            Models.DesarrollosModel modelo = new Models.DesarrollosModel();
            Entity.Filtro filtro = new Entity.Filtro();
          
            if (buscar != null)
            {
                Session["FiltroInformeDesde"] = Session["FiltroInformeDesde"];
                Session["FiltroInformeHasta"] = Session["FiltroInformeHasta"];
                modelo.listaDesarrollos = Session["registrosEncontrados"] as List<Entity.Desarrollo>;
            }
            if (limpiar != null)
            {
                Session["FiltroInformeDesde"] = Utiles.ReversaFecha(DateTime.Now);
                Session["FiltroInformeHasta"] = Utiles.ReversaFecha(DateTime.Now);
                filtro.FechaDesde = Utiles.FechaObtenerMinimo(DateTime.Now);
                filtro.FechaHasta = Utiles.FechaObtenerMaximo(DateTime.Now);
                Session["registrosEncontrados"] = DAL.DesarrollosDAL.ObtenerDesarrollos(filtro);
                modelo.listaDesarrollos = Session["registrosEncontrados"] as List<Entity.Desarrollo>;
            }
            return View(modelo);
        }

        public JsonResult GuardarDesarrollo(Entity.Desarrollo desarrollo)
        {
            DAL.DesarrollosDAL.InsertarDesarrollo(desarrollo);
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult EliminarDesarrollo (int idDesarrollo)
        {
            DAL.DesarrollosDAL.EliminarDesarrollo(idDesarrollo);

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult ObtenerEstados()
        {
            var lista = DAL.EstadoDesarrolloDAL.ObtenerEstadoDesarrollo();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerUsuarios()
        {
            Entity.Filtro filtro = new Entity.Filtro();
            var lista = DAL.UsuarioDAL.ObtenerUsuario(filtro);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult EditarDesarrollo(int idDesarrollo)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idDesarrollo;

            var lista = DAL.DesarrollosDAL.ObtenerDesarrollos(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult BusquedaFiltro(Entity.Filtro entity)
        {
            entity.FechaDesde = Utiles.FechaObtenerMinimo(entity.FechaDesde);
            entity.FechaHasta = Utiles.FechaObtenerMaximo(entity.FechaHasta);
            
            List<Entity.Desarrollo> historicosEncontrados = DAL.DesarrollosDAL.ObtenerDesarrollos(entity);
            Session["FiltroInformeDesde"] = Utiles.ReversaFecha(entity.FechaDesde);
            Session["FiltroInformeHasta"] = Utiles.ReversaFecha(entity.FechaHasta);
            Session["registrosEncontrados"] = historicosEncontrados;

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
