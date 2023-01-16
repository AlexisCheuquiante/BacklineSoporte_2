using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class InformacionController : Controller
    {
        // GET: Informacion
        public ActionResult Index()
        {
            Models.InformacionModel modelo = new Models.InformacionModel();
            Entity.Informacion filtro = new Entity.Informacion();
            modelo.ListaInformacion = DAL.InformacionDAL.ObtenerInformacion(filtro);

            return View(modelo);
        }
        public JsonResult GuardarInformacion(BacklineSoporte.Entity.Informacion informacion)
        {
            informacion.UsrCreador = SessionH.Usuario.Id;
            DAL.InformacionDAL.GuardaInformacion(informacion);
            if (informacion.Id == 0)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Informaciones";
                bitacora.Detalle = "Se crea una nueva información con el titulo de " + informacion.Titulo;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
            }
            if (informacion.Id > 0)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Informaciones";
                bitacora.Detalle = "Se edita la información " + informacion.Titulo;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerFecha()
        {
            string fechaActual = Utiles.ObtieneFechaAlRevez();
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = fechaActual, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult EliminarInformacion(int idInformacion)
        {
            Entity.Informacion filtro = new Entity.Informacion();
            filtro.Id = idInformacion;
            var lista = DAL.InformacionDAL.ObtenerInformacion(filtro);

            DAL.InformacionDAL.EliminarInformacion(idInformacion);
            Entity.Bitacora bitacora = new Entity.Bitacora();
            bitacora.Usr_Id = SessionH.Usuario.Id;
            bitacora.Modulo = "Informaciones";
            bitacora.Detalle = "Se elimina la información " + lista[0].Titulo;
            DAL.BitacoraDAL.InsertarBitacora(bitacora);

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult EditarInformacion(int idInformacion)
        {
            Entity.Informacion filtro = new Entity.Informacion();
            filtro.Id = idInformacion;

            var lista = DAL.InformacionDAL.ObtenerInformacion(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
 
}

