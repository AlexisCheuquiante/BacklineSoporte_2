using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BacklineSoporte.Controllers
{
    public class InformacionClienteController : Controller
    {
        // GET: InformacionCliente
        public ActionResult Index()
        {
            Models.InformacionModel modelo = new Models.InformacionModel();
            Entity.Informacion filtro = new Entity.Informacion();
            modelo.ListaInformacion = DAL.InformacionDAL.ObtenerInformacionCliente(filtro);
            return View(modelo);
        }
    }
}