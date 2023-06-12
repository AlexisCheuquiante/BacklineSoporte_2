using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;


namespace BacklineSoporte.Controllers
{
    public class CrearFarmaciaController : Controller
    {
        // GET: CrearEmpresa
        public ActionResult Index()
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }
            Models.CrearFarmaciaModel modelo = new Models.CrearFarmaciaModel();
            Entity.Filtro filtro = new Entity.Filtro();
            modelo.ListaFarmacias = DAL.CreacionFarmaciaDAL.ObtenerFarmacias(filtro);

            return View(modelo);
        }
        public JsonResult GuardarFarmacia(Entity.FarmaciasCreadas farmaciasCreadas)
        {
            if (farmaciasCreadas.Id == 0)
            {
                Entity.UsuarioFarmacia usuarioFarmacia = new Entity.UsuarioFarmacia();
                DAL.CreacionFarmaciaDAL.GuardarFarmacia(farmaciasCreadas);
                Session["EMP_Id"] = farmaciasCreadas.Id;
                usuarioFarmacia.Emp_Id = int.Parse(Session["EMP_Id"].ToString());
                usuarioFarmacia.Nombre = "usr" + farmaciasCreadas.Alias;
                usuarioFarmacia.UserName = "usr" + farmaciasCreadas.Alias;
                DAL.UsuarioFarmaciaDAL.GuardarUsuarioFarmacia(usuarioFarmacia);
                Entity.RelacionEmpUsr relacionEmpUsr = new Entity.RelacionEmpUsr();
                Session["Usr_Id"] = usuarioFarmacia.Id;
                relacionEmpUsr.Emp_Id = int.Parse(Session["EMP_Id"].ToString());
                relacionEmpUsr.Usr_Id = int.Parse(Session["Usr_Id"].ToString());
                DAL.RLEmpresaUsuarioDAL.GuardarRLEmpresaUsuario(relacionEmpUsr);
                int[] arreglo = new int[] { 1, 2, 3,4 };
                Entity.RLUsuarioRol rLUsuarioRol = new Entity.RLUsuarioRol();

                for (int i = 1; i < arreglo.Length; i++)
                {
                    rLUsuarioRol.Usr_Id = int.Parse(Session["Usr_Id"].ToString());
                    rLUsuarioRol.Rol_Id = i;
                    DAL.RLUsuarioRolDAL.GuardarRelacionUsuarioRol(rLUsuarioRol);

                }
            }
            else
            {
                DAL.CreacionFarmaciaDAL.GuardarFarmacia(farmaciasCreadas);
            }

            
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult EditarFarmacia(int idEmpresa)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idEmpresa;
            var lista = DAL.CreacionFarmaciaDAL.ObtenerFarmacias(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult EliminaFarmacia(int id)
        {
            try
            {
                BacklineSoporte.DAL.CreacionFarmaciaDAL.EliminaFarmacia(id);

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }

    }


}
