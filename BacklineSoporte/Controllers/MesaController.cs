using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class MesaController : Controller
    {
        // GET: Mesa
        public ActionResult Index()
        {
            var text = DateTime.Now.ToString();
            Session["FechaActual"] = text;
            Models.RequerimientoModel modelo = new Models.RequerimientoModel();
            Entity.Filtro filtro = new Entity.Filtro();
            modelo.ListaRequerimiento = DAL.RequerimientoDAL.ObtenerRequerimientoVisible(filtro);
            return View(modelo);
        }
        public JsonResult InsertarApruebo(int id)
        {
            try
            {
                BacklineSoporte.DAL.RequerimientoDAL.InsertarApruebo(id);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public JsonResult InsertarDesapruebo(int id)
        {
            try
            {
                BacklineSoporte.DAL.RequerimientoDAL.InsertarDesapruebo(id);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        
    }
}