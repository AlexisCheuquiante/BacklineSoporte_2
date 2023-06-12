using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BacklineSoporte.Controllers
{
    public class ConsultasController : Controller
    {
        // GET: Consultas
        public ActionResult Index()
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }
            BacklineSoporte.Models.ConsultasModel model = new Models.ConsultasModel();
            model.NombreUsuario = SessionH.Usuario.NombreCompleto;
            return View(model);
        }
    }
}