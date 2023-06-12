using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace BacklineSoporte.Controllers
{
    public class AgendaTablaController : Controller
    {
        // GET: AgendaTabla
        public ActionResult Index(string buscar, string limpiar, string actualizar)
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            BacklineSoporte.Models.AgendaModel modelo = new Models.AgendaModel();
            Entity.Filtro filtro = new Entity.Filtro();

            if (buscar != null)
            {
                Session["FiltroInformeDesde"] = Session["FiltroInformeDesde"];
                Session["FiltroInformeHasta"] = Session["FiltroInformeHasta"];

                modelo.ListaAgenda = Session["registrosEncontrados"] as List<Entity.Tarea>;
            }
            if (limpiar != null)
            {
                DateTime inicioSemana = Utiles.ObtenerInicioSemana(DateTime.Now);
                DateTime terminoSemana = Utiles.ObtenerTerminoSemana(DateTime.Now);

                Session["FiltroInformeDesde"] = Utiles.ReversaFecha(inicioSemana);
                Session["FiltroInformeHasta"] = Utiles.ReversaFecha(terminoSemana);
                filtro.FechaDesde = Utiles.FechaObtenerMinimo(inicioSemana);
                filtro.FechaHasta = Utiles.FechaObtenerMaximo(terminoSemana);
                modelo.ListaAgenda = DAL.TareaDAL.ObtenerTarea(filtro);
                Session["registrosEncontrados"] = modelo.ListaAgenda;
            }
            if (actualizar != null)
            {
                filtro.FechaDesde = Convert.ToDateTime(Session["FiltroInformeDesde"]);
                filtro.FechaHasta = Convert.ToDateTime(Session["FiltroInformeHasta"]);
                filtro.FechaDesde = Utiles.FechaObtenerMinimo(filtro.FechaDesde);
                filtro.FechaHasta = Utiles.FechaObtenerMaximo(filtro.FechaHasta);
                modelo.ListaAgenda = DAL.TareaDAL.ObtenerTarea(filtro);
                Session["registrosEncontrados"] = modelo.ListaAgenda;
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

            var idTareaInicial = entity.Id;

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

            if (idTareaInicial == 0)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Agenda";
                bitacora.Detalle = "Se crea la tarea con el siguiente detalle " + entity.Detalle;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
            }
            if (idTareaInicial > 0)
            {
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Agenda";
                bitacora.Detalle = "Se modifica la tarea con el siguiente detalle " + entity.Detalle;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
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
                bitacora.Detalle = "Se elimina la tarea de ID " + id;
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
            if (filtro.Tipo_Tarea_Id == -1)
            {
                filtro.Tipo_Tarea_Id = 0;
            }
            filtro.FechaDesde = Utiles.FechaObtenerMinimo(filtro.FechaDesde);
            filtro.FechaHasta = Utiles.FechaObtenerMaximo(filtro.FechaHasta);
            List<Entity.Tarea> historicosEncontrados = DAL.TareaDAL.ObtenerTarea(filtro);
            Session["FiltroTareaDesde"] = Utiles.ReversaFecha(filtro.FechaDesde);
            Session["FiltroTareaHasta"] = Utiles.ReversaFecha(filtro.FechaHasta);
            Session["registrosEncontrados"] = historicosEncontrados;


            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult RealizarTarea(int id)
        {
            DAL.TareaDAL.TareaRealizada(id);

            Entity.Bitacora bitacora = new Entity.Bitacora();
            bitacora.Usr_Id = SessionH.Usuario.Id;
            bitacora.Modulo = "Agenda";
            bitacora.Detalle = "Se da por realizada la tarea de ID " + id;
            DAL.BitacoraDAL.InsertarBitacora(bitacora);

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}