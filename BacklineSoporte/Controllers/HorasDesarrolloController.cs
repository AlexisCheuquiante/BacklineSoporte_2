using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace BacklineSoporte.Controllers
{
    public class HorasDesarrolloController : Controller
    {
        // GET: HorasDesarrollo
        public ActionResult Index(string id, string volver)
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Models.HorasDesarrolloModel modelo = new Models.HorasDesarrolloModel();
            Entity.Filtro filtro = new Entity.Filtro();
            if (volver != null)
            {
                id = volver;
            }
            filtro.Desa_Id = int.Parse(id);
            Session["idDesarrollo"] = int.Parse(id);
            modelo.Desa_Id = int.Parse(id);
            modelo.listaHoras = DAL.HorasDesarrolloDAL.ObtenerHorasDesarollo(filtro);
            return View(modelo);
        }
        public JsonResult InsertarHoras(Entity.HorasDesarrollo entity)
        {
            try
            {
                entity.Desa_Id = int.Parse(Session["idDesarrollo"].ToString());
                entity.Usr_Desarrollador_Id = SessionH.Usuario.Id;
                DAL.HorasDesarrolloDAL.InsertarHoras(entity);
                


                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public JsonResult CerrarHora(Entity.HorasDesarrollo entity)
        {
            entity.Fecha_Termino = DateTime.Now;
            DAL.HorasDesarrolloDAL.CerrarHora(entity);

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult Eliminar(int id)
        {
            DAL.HorasDesarrolloDAL.Eliminar(id);
            
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult EditarObservacion(Entity.HorasDesarrollo entity)
        {
            
            DAL.HorasDesarrolloDAL.EditarObservacion(entity);

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerObservacion(int idHora)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idHora;
            var lista = DAL.HorasDesarrolloDAL.ObtenerHorasDesarollo(filtro);
            //Session["IdConsulta"] = idFicha;

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}