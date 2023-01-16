using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class LoginClienteController : Controller
    {
        // GET: LoginCliente
        public ActionResult Index()
        {
           
            return View();
        }
        public JsonResult ValidarLogin(BacklineSoporte.Entity.Filtro entity)
        {

            List<BacklineSoporte.Entity.Usuario> usuario = new List<BacklineSoporte.Entity.Usuario>();
            usuario = BacklineSoporte.DAL.UsuarioDAL.ObtenerUsuarioCliente(entity);


            if (usuario != null && usuario.Count == 1)
            {
                SessionH.Usuario = usuario[0];
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult AccionSalir()
        {
            SessionH.Usuario = null;
            SessionH.Logueado = false;
            return RedirectToAction("Index", "LoginCliente");
        }
    }
}