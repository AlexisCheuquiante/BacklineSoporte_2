using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            Models.UsuariosModel modelo = new Models.UsuariosModel();
            Entity.Filtro filtro = new Entity.Filtro();
            modelo.ListaUsuarios = DAL.UsuarioDAL.ObtenerUsuario(filtro);
            return View(modelo);
        }
       

        public JsonResult GuardarUsuario (BacklineSoporte.Entity.Usuario usuario)
        {
            DAL.UsuarioDAL.GuardaUsuario(usuario);
            if (usuario.Id == 0)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Mantenedor de usuarios";
                bitacora.Detalle = "Se crea un usuario para " + usuario.NombreCompleto;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
            }
            if (usuario.Id > 0)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Mantenedor de usuarios";
                bitacora.Detalle = "Se edita el usuario " + usuario.NombreCompleto;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult EliminarUsuario(int idUsuario)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idUsuario;
            var lista = DAL.UsuarioDAL.ObtenerUsuario(filtro);

            DAL.UsuarioDAL.EliminarUsuario(idUsuario);
            Entity.Bitacora bitacora = new Entity.Bitacora();
            bitacora.Usr_Id = SessionH.Usuario.Id;
            bitacora.Modulo = "Mantenedor de usuarios";
            bitacora.Detalle = "Se elimina el usuario " + lista[0].NombreCompleto;
            DAL.BitacoraDAL.InsertarBitacora(bitacora);
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult EditarUsuario(int idUsuario)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idUsuario;

            var lista = DAL.UsuarioDAL.ObtenerUsuario(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerRoles()
        {
            var lista = DAL.RolDAL.ObtenerRoles();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
