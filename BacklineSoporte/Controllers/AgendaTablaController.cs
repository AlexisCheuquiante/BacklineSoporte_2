using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BacklineSoporte.Controllers
{
    public class AgendaTablaController : Controller
    {
        // GET: AgendaTabla
        public ActionResult Index(string limpiar)
        {
            BacklineSoporte.Models.AgendaModel modelo = new Models.AgendaModel();
            Entity.Filtro filtro = new Entity.Filtro();

            if (limpiar != null)
            {
                DateTime inicioSemana = Utiles.ObtenerInicioSemana(DateTime.Now);
                DateTime terminoSemana = Utiles.ObtenerTerminoSemana(DateTime.Now);

                Session["FiltroTareaDesde"] = Utiles.ReversaFecha(inicioSemana);
                Session["FiltroTareaHasta"] = Utiles.ReversaFecha(terminoSemana);
                filtro.FechaDesde = Utiles.FechaObtenerMinimo(inicioSemana);
                filtro.FechaHasta = Utiles.FechaObtenerMaximo(terminoSemana);
                modelo.ListaAgenda = DAL.TareaDAL.ObtenerTarea(filtro);
                Session["registrosEncontrados"] = modelo.ListaAgenda;
            }
            return View(modelo);
        }
    }
}