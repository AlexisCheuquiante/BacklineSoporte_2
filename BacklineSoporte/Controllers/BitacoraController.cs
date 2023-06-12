using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BacklineSoporte.Controllers
{
    public class BitacoraController : Controller
    {
        // GET: Bitacora
        public ActionResult Index()
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }
            Models.BitacoraModel modelo = new Models.BitacoraModel();
            modelo.Bitacora = DAL.BitacoraDAL.ObtenerBitacora();
            return View(modelo);
        }
    }
}