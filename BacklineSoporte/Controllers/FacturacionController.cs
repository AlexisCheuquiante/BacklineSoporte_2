using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;
using System.Configuration;

namespace BacklineSoporte.Controllers
{
    public class FacturacionController : Controller
    {
        // GET: Facturacion
        public ActionResult Index(int id)
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        public JsonResult ObtenerProductoFacturado(Entity.Filtro entity)
        {
            var lista = DAL.ProductoFacturadoDAL.ObtenerProductoFacturado(entity);

            if (lista == null || lista.Count == 0)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerEstadoFactura()
        {
            var lista = DAL.EstadoFacturaDAL.ObtenerEstadoFactura();

            if (lista == null || lista.Count == 0)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GuardaFactura(Entity.Facturacion entity)
        {
            try
            {
                if (entity.Id == 0)
                {
                    entity.Usr_Modificador_Id = 0;
                }
                if (entity.Id > 0)
                {
                    entity.Usr_Modificador_Id = SessionH.Usuario.Id;
                }
                entity.Usr_Creador_Id = SessionH.Usuario.Id;
                DAL.FacturacionDAL.GuardaFactura(entity);

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
    }
}
