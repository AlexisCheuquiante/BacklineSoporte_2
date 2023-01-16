using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BacklineSoporte.Controllers
{
    public class ComentarioController : Controller
    {
        // GET: Comentario
        public ActionResult Index(int id)
        {
            Models.ComentarioModel modelo = new Models.ComentarioModel();
            modelo.Id_Requerimiento = id;
            Entity.Comentario comentarioFiltro = new Entity.Comentario();
            comentarioFiltro.Requerimiento_Id = id;
            modelo.ListaComentarios = DAL.ComentarioDAL.ObtenerComentario(comentarioFiltro);
            Session["idRequerimiento"] = id;
            return View(modelo);
        }
        public JsonResult GuardarComentario(BacklineSoporte.Entity.Comentario comentario)
        {
            comentario.UsuarioCreador_Id = SessionH.Usuario.Id;
            comentario.Requerimiento_Id = int.Parse(Session["idRequerimiento"].ToString());
            DAL.ComentarioDAL.GuardaComentario(comentario);

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}