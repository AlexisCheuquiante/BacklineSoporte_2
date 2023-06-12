using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class AvisoCobroController : Controller
    {
        // GET: AvisoCobro
        public ActionResult Index()
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Models.AvisoCobroModel modelo = new Models.AvisoCobroModel();
            modelo.ListaAvisos = DAL.EmpresaDAL.ObtenerEmpresas();
            return View(modelo);
        }
        public JsonResult ObtenerIntervaloTiempo()
        {
            var lista = DAL.TiempoDAL.ObtenerIntervaloTiempo();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerEmpresas()
        {
            var lista = DAL.EmpresaDAL.ObtenerEmpresas();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerAviso(Entity.Filtro entity)
        {
            if (entity.Id == 0)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Nada", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            var empresaAviso = DAL.EmpresaDAL.ObtenerAviso(entity);

            if (empresaAviso == null || empresaAviso.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = empresaAviso[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult UpdateMensajeCorte(BacklineSoporte.Entity.Empresa aviso)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = aviso.Id;
            var lista = DAL.EmpresaDAL.ObtenerEmpresasEdit(filtro);

            DAL.EmpresaDAL.UpdateMensajeCorte(aviso);

            Entity.Bitacora bitacora = new Entity.Bitacora();
            bitacora.Usr_Id = SessionH.Usuario.Id;
            bitacora.Modulo = "Mensaje de aviso";
            bitacora.Detalle = "Se sube el aviso de deuda para la empresa " + lista[0].NombreEmpresa;
            DAL.BitacoraDAL.InsertarBitacora(bitacora);

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerEmpresasEdit(int id)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = id;
            var lista = DAL.EmpresaDAL.ObtenerEmpresasEdit(filtro);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}