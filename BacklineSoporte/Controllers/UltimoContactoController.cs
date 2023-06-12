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
    public class UltimoContactoController : Controller
    {
        // GET: UltimoContacto
        public ActionResult Index(int id)
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            BacklineSoporte.Models.UltimoContactoModel modelo = new Models.UltimoContactoModel();
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Ficha_Cliente_Id = id;
            modelo.listaUltimosContactos = DAL.FichaClienteDAL.ObtenerUltimosContactos(filtro);
            Session["idFichaCliente"] = id;
            return View(modelo);
        }
        public JsonResult ObtenerMotivoContacto(Entity.Filtro entity)
        {
            var lista = DAL.MotivoContactoDAL.ObtenerMotivoContacto(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerEstadoUltimoContacto()
        {
            var lista = DAL.EstadoUltimoContactoDAL.ObtenerEstadoUltimoContacto();

            if (lista == null || lista.Count == 0)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GuardarUltimoContacto(Entity.FichaCliente fichaCliente)
        {
            try
            {
                fichaCliente.Id = int.Parse(Session["idFichaCliente"].ToString());
                BacklineSoporte.DAL.FichaClienteDAL.InsertarUltimoContacto(fichaCliente);
                
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public JsonResult ObtenerUltimoContacto(int id)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = id;
            var lista = DAL.FichaClienteDAL.ObtenerUltimosContactos(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}