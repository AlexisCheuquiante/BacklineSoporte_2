using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace BacklineSoporte.Controllers
{
    public class ConsultasFarmaciasController : Controller
    {
        // GET: ConsultasFarmacias
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ObtenerEmpresas()
        {
            var lista = DAL.EmpresaDAL.ObtenerEmpresas();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerSolicitante(Entity.Filtro entity)
        {
            if (entity.EmpId == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Ninguno", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            entity.Eliminado = true;
            List<Entity.Usuario> usuarioSolicitante = DAL.UsuarioDAL.ObtenerSolicitante(entity);

            if (usuarioSolicitante == null || usuarioSolicitante.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = usuarioSolicitante, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }
        public JsonResult ObtenerTipoDocumetoConsulta()
        {
            var lista = DAL.TipoDocumentoConsultaDAL.ObtenerTipoDocumetoConsulta();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerDocumentosConsulta(Entity.Filtro entity)
        {
            if (entity.EmpId == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Ninguno", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            List<Entity.DocumentoConsulta> listaDocumentos = DAL.DocumentoConsultaDAL.ObtenerDocumentosConsulta(entity);

            if (listaDocumentos == null || listaDocumentos.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = listaDocumentos, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }
    }
}