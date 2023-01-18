using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class DesarrollosController : Controller
    {
        // GET: Desarrollos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GuardarDesarrollo(Entity.Desarrollo desarrollo)
        {
            DAL.DesarrollosDAL.InsertarDesarrollo(desarrollo);
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
    }
}
