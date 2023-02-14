using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace BacklineSoporte.Controllers
{
    public class AgendaController : Controller
    {
         
        // GET: Agenda
        public ActionResult Index( string buscar , string limpiar, string actualizar)
        {
            var text = DateTime.Now.ToString();
            Session["FechaActual"] = text;
            Models.TareaModel modelo = new Models.TareaModel();
            Entity.Filtro filtro = new Entity.Filtro();


            if (buscar != null)
            {
                Session["FiltroTareaDesde"] = Session["FiltroTareaDesde"];
                Session["FiltroTareaHasta"] = Session["FiltroTareaHasta"];

                modelo.ListaTarea = Session["registrosEncontrados"] as List<Entity.Tarea>;
            }
            if (limpiar != null)
            {
                DateTime inicioSemana = Utiles.ObtenerInicioSemana(DateTime.Now);
                DateTime terminoSemana = Utiles.ObtenerTerminoSemana(DateTime.Now);

                Session["FiltroTareaDesde"] = Utiles.ReversaFecha(inicioSemana);
                Session["FiltroTareaHasta"] = Utiles.ReversaFecha(terminoSemana);
                filtro.FechaDesde = Utiles.FechaObtenerMinimo(inicioSemana);
                filtro.FechaHasta = Utiles.FechaObtenerMaximo(terminoSemana);
                modelo.ListaTarea = DAL.TareaDAL.ObtenerTarea(filtro);
                Session["registrosEncontrados"] = modelo.ListaTarea;
            }
            if (actualizar != null)
            {
                filtro.FechaHasta = Convert.ToDateTime(Session["FiltroTareaHasta"]);
                filtro.FechaDesde = Convert.ToDateTime(Session["FiltroTareaDesde"]);
                filtro.FechaDesde = Utiles.FechaObtenerMinimo(filtro.FechaDesde);
                filtro.FechaHasta = Utiles.FechaObtenerMaximo(filtro.FechaHasta);
                modelo.ListaTarea = DAL.TareaDAL.ObtenerTarea(filtro);
                Session["registrosEncontrados"] = modelo.ListaTarea;
            }
            
            return View(modelo);
        }

        public JsonResult ObtenerTipoTarea()
        {
            var lista = DAL.TipoTareaDAL.ObtenerTipoTarea();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult ObtenerModalidadTarea()
        {
            var lista = DAL.ModalidadTareaDAL.ObtenerModalidadTarea();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult ObtenerUsuarios()
        {
            Entity.Filtro filtro = new Entity.Filtro();
            var lista = DAL.UsuarioDAL.ObtenerUsuario(filtro);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult InsertarTarea(BacklineSoporte.Entity.Tarea entity, string idsUsuarios)
        {
            entity.Usr_Creador_Id = SessionH.Usuario.Id;
            
            DAL.TareaDAL.InsertarTarea(entity);
            var idTarea = entity.Id;

            List<int> ids = PreparaRLUsuario(idsUsuarios);
            int contador = 1;
            foreach (var a in ids)
            {
                Entity.RlTareaUsuario rlTareaUsuario = new Entity.RlTareaUsuario();
                rlTareaUsuario.Tar_Id = idTarea;
                rlTareaUsuario.Usr_Id = a;
                rlTareaUsuario.Contador = contador;
                contador++;
                DAL.RlTareaUsuarioDAL.GuardarRLTareaUsuario(rlTareaUsuario);
            }


            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
          
        }
        List<int> PreparaRLUsuario(string idsUsuarios)
        {
            string[] split = idsUsuarios.Split(new Char[] { ',' });
            List<int> retorno = new List<int>();

            foreach (var a in split)
            {
                int v;
                if (int.TryParse(a, out v))
                {
                    retorno.Add(int.Parse(a));
                }
            }
            return retorno;
        }

        public JsonResult RealizarTarea(BacklineSoporte.Entity.Tarea tarea, int id)
        {

            tarea.Id = id;
            DAL.TareaDAL.TareaRealizada(tarea, id);


            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }
        public JsonResult EditarTarea(int idTarea)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idTarea;
            filtro.TraeUsuario = true;
            var lista = DAL.TareaDAL.ObtenerTarea(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult EliminarTarea(int id)
        {
            try
            {
                BacklineSoporte.DAL.TareaDAL.EliminarTarea(id);
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Agenda";
                bitacora.Detalle = "Se elimina la tarea" + id;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public ActionResult BusquedaFiltro(Entity.Filtro filtro)
        {   
            filtro.FechaDesde = Utiles.FechaObtenerMinimo(filtro.FechaDesde);
            filtro.FechaHasta = Utiles.FechaObtenerMaximo(filtro.FechaHasta);

            List<Entity.Tarea> historicosEncontrados = DAL.TareaDAL.ObtenerTarea(filtro);
            Session["FiltroTareaDesde"] = Utiles.ReversaFecha(filtro.FechaDesde);
            Session["FiltroTareaHasta"] = Utiles.ReversaFecha(filtro.FechaHasta);

            Session["registrosEncontrados"] = historicosEncontrados;


            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
