using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            BacklineSoporte.Models.UsuariosModel model = new Models.UsuariosModel();
            model.Usuario = Request.Cookies["BACK_USER"] != null ? Request.Cookies["BACK_USER"].Value.ToString() : "";
            model.Contraseña = Request.Cookies["BACK_PASS"] != null ? Request.Cookies["BACK_PASS"].Value.ToString() : "";
            return View(model);
        }
        public JsonResult ValidarLogin(BacklineSoporte.Entity.Filtro entity)
        {

            List<BacklineSoporte.Entity.Usuario> usuario = new List<BacklineSoporte.Entity.Usuario>();
            usuario = BacklineSoporte.DAL.UsuarioDAL.ObtenerUsuario(entity);


            if (usuario != null && usuario.Count == 1)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = usuario[0].Id;
                bitacora.Modulo = "Login interno";
                bitacora.Detalle = "Ingresa a la plataforma " + usuario[0].NombreCompleto;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
                SessionH.Usuario = usuario[0];

                System.Web.HttpCookie c1 = new System.Web.HttpCookie("BACK_USER");
                c1.Value = entity.UsuarioStr;
                c1.Expires = DateTime.Now.AddYears(10);
                Response.Cookies.Add(c1);


                System.Web.HttpCookie c2 = new System.Web.HttpCookie("BACK_PASS");
                c2.Value = entity.Password;
                c2.Expires = DateTime.Now.AddYears(10);
                Response.Cookies.Add(c2);

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult AccionSalir()
        {
            SessionH.Usuario = null;
            SessionH.Logueado = false;
            return RedirectToAction("Index", "Login");
        }
    }
}
