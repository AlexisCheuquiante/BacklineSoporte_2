using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BacklineSoporte.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            BacklineSoporte.Models.HomeModel model = new Models.HomeModel();
            model.NombreUsuario = SessionH.Usuario.NombreCompleto;
            return View(model);
        }
    }
}