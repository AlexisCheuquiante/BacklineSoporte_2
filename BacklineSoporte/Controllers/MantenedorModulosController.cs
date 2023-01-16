using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace BacklineSoporte.Controllers
{
    public class MantenedorModulosController : Controller
    {
        // GET: MantenedorModulos
        public ActionResult Index()
        {
            Models.MantenedorModulosModel modelo = new Models.MantenedorModulosModel();
            Entity.Filtro filtro = new Entity.Filtro();
            modelo.ListaModulos = DAL.ModuloDAL.ObtenerModulos(filtro);
            return View(modelo);
        }
        public JsonResult EditarModulo(int idModulo)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idModulo;
            var lista = DAL.ModuloDAL.ObtenerModulos(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GuardaModulo(BacklineSoporte.Entity.Modulo modulo)
        {
            DAL.ModuloDAL.GuardaModulo(modulo);
            if (modulo.Id == 0)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Mantenedor de modulos";
                bitacora.Detalle = "Se crea el modulo " + modulo.ModuloStr;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
            }
            if (modulo.Id > 0)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Mantenedor de modulos";
                bitacora.Detalle = "Se edita el modulo " + modulo.ModuloStr;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
            }
            
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult EliminarModulo(int idModulo)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idModulo;
            var lista = DAL.ModuloDAL.ObtenerModulos(filtro);

            DAL.ModuloDAL.EliminarModulo(idModulo);

            Entity.Bitacora bitacora = new Entity.Bitacora();
            bitacora.Usr_Id = SessionH.Usuario.Id;
            bitacora.Modulo = "Mantenedor de modulos";
            bitacora.Detalle = "Se elimina el modulo " + lista[0].ModuloStr;
            DAL.BitacoraDAL.InsertarBitacora(bitacora);
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}