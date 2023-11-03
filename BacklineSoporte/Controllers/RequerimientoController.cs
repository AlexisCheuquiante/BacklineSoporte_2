using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace BacklineSoporte.Controllers
{
    public class RequerimientoController : Controller
    {
        // GET: Requerimiento
        public ActionResult Index(string buscar, string limpiar, string actualizar)
        {
            if (BacklineSoporte.SessionH.Usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var text = DateTime.Now.ToString();
            Session["FechaActual"] = text;
            Models.RequerimientoModel modelo = new Models.RequerimientoModel();
            Entity.Filtro filtro = new Entity.Filtro();

            if (actualizar != null)
            {
                buscar = null;
                limpiar = null;
                var numero_buscado = 0;
                var emp_id = 0;
                var tipo_Software = 0;
                var responsable = 0;
                var estado = 0;

                if (Session["numero_Buscado"] != null)
                {
                    numero_buscado = int.Parse(Session["numero_Buscado"].ToString());
                }
                if (Session["FiltroEmpresa"] != null)
                {
                    emp_id = int.Parse(Session["FiltroEmpresa"].ToString());
                }
                if (Session["FiltroTipoSoftware"] != null)
                {
                    tipo_Software = int.Parse(Session["FiltroTipoSoftware"].ToString());
                }
                if (Session["FiltroResponsable"] != null)
                {
                   responsable = int.Parse(Session["FiltroResponsable"].ToString());
                }
                if (Session["FiltroEstado"] != null)
                {
                    estado = int.Parse(Session["FiltroEstado"].ToString());
                }

                if (numero_buscado > 0)
                {
                    filtro.Id = numero_buscado;
                    Session["registrosEncontrados"] = DAL.RequerimientoDAL.ObtenerRequerimiento_Numero(filtro);
                    modelo.ListaRequerimiento = Session["registrosEncontrados"] as List<Entity.Requerimiento>;
                }
                else
                {
                    filtro.FechaDesde = Convert.ToDateTime(Session["FiltroInformeDesde"]);
                    filtro.FechaHasta = Convert.ToDateTime(Session["FiltroInformeHasta"]);
                    filtro.Tipo_Software = tipo_Software;
                    filtro.EmpId = emp_id;
                    filtro.Responsable = responsable;
                    filtro.Estado = estado;
                    Session["registrosEncontrados"] = DAL.RequerimientoDAL.ObtenerRequerimiento(filtro);
                    modelo.ListaRequerimiento = Session["registrosEncontrados"] as List<Entity.Requerimiento>;
                }

            }
            if (buscar != null)
            {
                Session["FiltroInformeDesde"] = Session["FiltroInformeDesde"];
                Session["FiltroInformeHasta"] = Session["FiltroInformeHasta"];
                modelo.ListaRequerimiento = Session["registrosEncontrados"] as List<Entity.Requerimiento>;
            }
            if (limpiar != null)
            {
                Session["FiltroInformeDesde"] = Utiles.ReversaFecha(DateTime.Now);
                Session["FiltroInformeHasta"] = Utiles.ReversaFecha(DateTime.Now);
                filtro.FechaDesde = Utiles.FechaObtenerMinimo(DateTime.Now);
                filtro.FechaHasta = Utiles.FechaObtenerMaximo(DateTime.Now);
                Session["registrosEncontrados"] = DAL.RequerimientoDAL.ObtenerRequerimiento(filtro);
                modelo.ListaRequerimiento = Session["registrosEncontrados"] as List<Entity.Requerimiento>;
            }
            
            return View(modelo);
        }
        public JsonResult ObtenerModulos(Entity.Filtro entity)
        {
            var lista = DAL.ModuloDAL.ObtenerModulos(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerUsuario()
        {
            Entity.Filtro filtro = new Entity.Filtro();
            var lista = DAL.UsuarioDAL.ObtenerUsuario(filtro);

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
        public JsonResult ObtenerSolicitante(Entity.Filtro entity)
        {
            if (entity.EmpId == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Ninguno", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            entity.Eliminado = false;
            List<Entity.Usuario> usuarioSolicitante = DAL.UsuarioDAL.ObtenerSolicitante(entity);

            if (usuarioSolicitante == null || usuarioSolicitante.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = usuarioSolicitante, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerTipoPrioridad()
        {
            var lista = DAL.PrioridadDAL.ObtenerTipoPrioridad();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerTipoSoftware()
        {
            var lista = DAL.SoftwareDAL.ObtenerTipoSoftware();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerEstado()
        {
            var lista = DAL.EstadoRequeDAL.ObtenerEstadoReque();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult InsertarRequerimiento(BacklineSoporte.Entity.Requerimiento requerimiento)
        {
            try
            {
                var idInsertado = requerimiento.Id;
                requerimiento.UsrCreador = SessionH.Usuario.Id;

                BacklineSoporte.DAL.RequerimientoDAL.InsertarRequerimiento(requerimiento);
                if (idInsertado == 0)
                {
                    Entity.Bitacora bitacora = new Entity.Bitacora();
                    bitacora.Usr_Id = SessionH.Usuario.Id;
                    bitacora.Modulo = "Requerimiento";
                    bitacora.Detalle = "Se crea el requerimiento N°" + requerimiento.Id;
                    DAL.BitacoraDAL.InsertarBitacora(bitacora);
                }
                if (idInsertado > 0)
                {
                    Entity.Bitacora bitacora = new Entity.Bitacora();
                    bitacora.Usr_Id = SessionH.Usuario.Id;
                    bitacora.Modulo = "Requerimiento";
                    bitacora.Detalle = "Se edita el requerimiento N°" + requerimiento.Id;
                    DAL.BitacoraDAL.InsertarBitacora(bitacora);
                }

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public JsonResult EditarRequerimiento(int idRequerimiento)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idRequerimiento;
            var lista = DAL.RequerimientoDAL.ObtenerRequerimiento(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult EliminarRequerimiento(int id)
        {
            try
            {
                BacklineSoporte.DAL.RequerimientoDAL.EliminarRequerimiento(id);
                Entity.Bitacora bitacora = new Entity.Bitacora();
                bitacora.Usr_Id = SessionH.Usuario.Id;
                bitacora.Modulo = "Requerimiento";
                bitacora.Detalle = "Se elimina el requerimiento N°" + id;
                DAL.BitacoraDAL.InsertarBitacora(bitacora);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public ActionResult BusquedaFiltro(Entity.Filtro entity)
        {
            Session["numero_Buscado"] = null;

            entity.FechaDesde = Utiles.FechaObtenerMinimo(entity.FechaDesde);
            entity.FechaHasta = Utiles.FechaObtenerMaximo(entity.FechaHasta);
            if (entity.Tipo_Software == -1)
            {
                entity.Tipo_Software = 0;
            }
            if (entity.EmpId == -1)
            {
                entity.EmpId = 0;
            }
            if (entity.Responsable == -1)
            {
                entity.Responsable = 0;
            }
            if (entity.Estado == -1)
            {
                entity.Estado = 0;
            }
            List<Entity.Requerimiento> historicosEncontrados = DAL.RequerimientoDAL.ObtenerRequerimiento(entity);
            Session["FiltroInformeDesde"] = Utiles.ReversaFecha(entity.FechaDesde);
            Session["FiltroInformeHasta"] = Utiles.ReversaFecha(entity.FechaHasta);
            Session["registrosEncontrados"] = historicosEncontrados;
            if (entity.Tipo_Software > 0)
            {
                Session["FiltroTipoSoftware"] = entity.Tipo_Software;
            }
            if (entity.EmpId > 0)
            {
                Session["FiltroEmpresa"] = entity.EmpId;
            }
            if (entity.Responsable > 0)
            {
                Session["FiltroResponsable"] = entity.Responsable;
            }
            if (entity.Estado > 0)
            {
                Session["FiltroEstado"] = entity.Estado;
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public FileContentResult ExportToExcel()
        {
            var timestamp = Utiles.ObtenerTimeStamp();

            List<Entity.Requerimiento> lista = Session["registrosEncontrados"] as List<Entity.Requerimiento>;

            if (lista != null && lista.Count > 0)
            {
                string[] columns = { "Id", "FechaMostrar", "SoftwareStr", "NombreEmpresa", "NombreSolicitante", "Modulo", "Funcionalidad", "Fecha_Solucion_Str", "Prioridad", "Clasificacion_Str", "NombreResponsable", "Estado_Reque"};
                byte[] filecontent = Code.ExcelExportHelper.ExportExcel(lista, "Requerimientos", true, columns);
                return File(filecontent, Code.ExcelExportHelper.ExcelContentType, "Requerimientos_Soporte_" + "(" + timestamp + ")" + ".xlsx");
            }
            else
            {
                return null;
            }

        }
        public ActionResult ObtenerRequerimiento_Numero(Entity.Filtro entity)
        {
            if (entity.Id <= 0)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "errorNumero", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
            List<Entity.Requerimiento> historicosEncontrados = DAL.RequerimientoDAL.ObtenerRequerimiento_Numero(entity);
            Session["numero_Buscado"] = entity.Id;
            Session["registrosEncontrados"] = historicosEncontrados;

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}