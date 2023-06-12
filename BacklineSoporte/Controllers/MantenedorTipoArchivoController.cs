using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class MantenedorTipoArchivoController : Controller
    {
        // GET: MantenedorTipoArchivo
        public ActionResult Index()
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Models.TipoArchivoModel modelo = new Models.TipoArchivoModel();
            Entity.Filtro filtro = new Entity.Filtro();
            modelo.ListaTipoArchivo = DAL.TipoArchivoDAL.ObtenerTipoArchivo(filtro);
            return View(modelo);
        }

        public JsonResult EditarTipoArchivo(int idTipoArchivo)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idTipoArchivo;
            var lista = DAL.TipoArchivoDAL.ObtenerTipoArchivo(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GuardaTipoArchivo(BacklineSoporte.Entity.TipoArchivo tipoArchivo)
        {
            DAL.TipoArchivoDAL.GuardaTipoArchivo(tipoArchivo);
            if (tipoArchivo.Id == 0)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Mantenedor de tipo archivo";
                bitacora.Detalle = "Se crea el tipo de archivo " + tipoArchivo.Descripcion;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
            }
            if (tipoArchivo.Id > 0)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Mantenedor de tipo de archivos";
                bitacora.Detalle = "Se edita el tipo de archivo " + tipoArchivo.Descripcion;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult EliminarTipoArchivo(int idTipoArchivo)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idTipoArchivo;
            var lista = DAL.TipoArchivoDAL.ObtenerTipoArchivo(filtro);

            DAL.TipoArchivoDAL.EliminarTipoArchivo(idTipoArchivo);

            Entity.Bitacora bitacora = new Entity.Bitacora();
            bitacora.Usr_Id = SessionH.Usuario.Id;
            bitacora.Modulo = "Mantenedor de tipo de archivos";
            bitacora.Detalle = "Se elimina el tipo de archivo " + lista[0].Descripcion;
            DAL.BitacoraDAL.InsertarBitacora(bitacora);
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
