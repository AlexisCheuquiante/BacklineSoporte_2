using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace BacklineSoporte.Controllers
{
    public class MantenedorUsuariosController : Controller
    {
        // GET: MantenedorUsuarios
        public ActionResult Index(int id)
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Models.UsuariosFarmaciaModel modelo = new Models.UsuariosFarmaciaModel();
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.EmpId = id;
            Session["Emp_Id"] = id;
            modelo.listaUsuarioFarmacias = DAL.UsuarioFarmaciaDAL.ObtenerUsuarioFarmacia(filtro);

            return View(modelo);
        }

        public JsonResult GuardarUsuario(Entity.UsuarioFarmacia usuarioFarmacia)
        {

            if (usuarioFarmacia.Id == 0)
            {

                usuarioFarmacia.Emp_Id = int.Parse(Session["Emp_Id"].ToString());
                DAL.UsuarioFarmaciaDAL.GuardarUsuarioMantenedor(usuarioFarmacia);
                Entity.RelacionEmpUsr relacionEmpUsr = new Entity.RelacionEmpUsr();
                Session["Usr_Id"] = usuarioFarmacia.Id;
                relacionEmpUsr.Emp_Id = int.Parse(Session["Emp_Id"].ToString());
                relacionEmpUsr.Usr_Id = int.Parse(Session["Usr_Id"].ToString());
                DAL.RLEmpresaUsuarioDAL.GuardarRLEmpresaUsuario(relacionEmpUsr);
                int[] arreglo = new int[] { 1, 2, 3, 4 };
                Entity.RLUsuarioRol rLUsuarioRol = new Entity.RLUsuarioRol();

                for (int i = 1; i < arreglo.Length; i++)
                {
                    rLUsuarioRol.Usr_Id = int.Parse(Session["Usr_Id"].ToString());
                    rLUsuarioRol.Rol_Id = i;
                    DAL.RLUsuarioRolDAL.GuardarRelacionUsuarioRol(rLUsuarioRol);

                }

            }else
            {
                usuarioFarmacia.Emp_Id = int.Parse(Session["Emp_Id"].ToString());
                DAL.UsuarioFarmaciaDAL.GuardarUsuarioMantenedor(usuarioFarmacia);
            }



                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult EliminarUsuario(int idUsuario)
        {
            

            DAL.UsuarioFarmaciaDAL.EliminarUsuario(idUsuario);
            
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult EditarUsuario(int idUsuario)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idUsuario;

            var lista = DAL.UsuarioFarmaciaDAL.ObtenerUsuarioFarmacia(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
