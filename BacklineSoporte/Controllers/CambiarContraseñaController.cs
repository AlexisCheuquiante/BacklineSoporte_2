using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class CambiarContraseñaController : Controller
    {
        // GET: CambiarContraseña
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CambiarClave(BacklineSoporte.Entity.Usuario entity)
        {
            try
            {
                entity.Id = SessionH.Usuario.Id;
                BacklineSoporte.DAL.UsuarioDAL.CambiarClave(entity);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public ActionResult AccionSalir()
        {
            SessionH.Usuario = null;
            SessionH.Logueado = false;
            return RedirectToAction("Index", "Login");
        }
    }
}