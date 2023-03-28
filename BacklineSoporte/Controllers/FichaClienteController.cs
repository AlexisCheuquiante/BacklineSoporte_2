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
    public class FichaClienteController : Controller
    {
        // GET: FichaCliente
        public ActionResult Index()
        {
            Session["ListaEstablecimientos"] = new List<Entity.Establecimiento>(); ;
            Models.FichaClienteModel modelo = new Models.FichaClienteModel();
            Entity.Filtro filtro = new Entity.Filtro();
            modelo.ListaFichaCliente = DAL.FichaClienteDAL.ObtenerFicha(filtro);
            return View(modelo);

        }

        public JsonResult ObtenerEntidad(Entity.Filtro entity)
        {
            var lista = DAL.EntidadDAL.ObtenerEntidades(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerDetalleCotizacion(Entity.Filtro entity)
        {
            var lista = DAL.DetalleCotizacionDAL.ObtenerDetalleCotizacion(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult ObtenerRegion(Entity.Filtro entity)
        {
            var lista = DAL.RegionDAL.ObtenerRegiones(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult ObtenerEstadoFicha(Entity.Filtro entity)
        {
            var lista = DAL.EstadoFichaDAL.ObtenerEstadoFicha(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerMotivoContacto(Entity.Filtro entity)
        {
            var lista = DAL.MotivoContactoDAL.ObtenerMotivoContacto(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerTipoContratacion(Entity.Filtro entity)
        {
            var lista = DAL.TipoContratacionDAL.ObtenerTipoContratacion(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult ObtenerProveedor(Entity.Filtro entity)
        {
            var lista = DAL.ProveedorBeDAL.ObtenerProveedorBE(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GuardarFicha(Entity.FichaCliente fichaCliente)
        {
            try
            {
                var Editar = false;

                fichaCliente.Usr_Id = SessionH.Usuario.Id;
                if (fichaCliente.Id == 0)
                {
                    fichaCliente.Editar = false;
                }
                if (fichaCliente.Id > 0)
                {
                    fichaCliente.Editar = true;
                }
                DAL.FichaClienteDAL.GuardaFicha(fichaCliente);
                var idFichaCliente = fichaCliente.Id;

                Entity.Filtro filtro = new Entity.Filtro();
                filtro.Ficha_Cliente_Id = idFichaCliente;
                List<Entity.FichaCliente> lista = BacklineSoporte.DAL.FichaClienteDAL.ObtenerEditarFicha(filtro);
                Editar = lista[0].Editar;

                fichaCliente.Id = idFichaCliente;
                fichaCliente.Editar = Editar;
                BacklineSoporte.DAL.FichaClienteDAL.InsertarDatosCotizacion(fichaCliente);

                BacklineSoporte.DAL.FichaClienteDAL.InsertarDatosContratacion(fichaCliente);

                BacklineSoporte.DAL.FichaClienteDAL.InsertarUltimoContacto(fichaCliente);
                List<Entity.Establecimiento> listadoEstablecimientos = Session["ListaEstablecimientos"] as List<Entity.Establecimiento>;
                foreach (var establecimiento in listadoEstablecimientos)
                {
                    establecimiento.Fich_Id = fichaCliente.Id;
                    DAL.EstablecimientoDAL.InsertarEstablecimiento(establecimiento);
                }
                Session["ListaEstablecimientos"] = new List<Entity.Establecimiento>(); ;

                BacklineSoporte.DAL.FichaClienteDAL.InsertarDatosContacto(fichaCliente);
                

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public JsonResult AgregarEstablecimiento(Entity.Establecimiento entity)
        {
            try
            {
                if (Session["ListaEstablecimientos"] == null)
                {
                    List<Entity.Establecimiento> listadoEstablecimientos = new List<Entity.Establecimiento>();
                    listadoEstablecimientos.Add(entity);
                    Session["ListaEstablecimientos"] = listadoEstablecimientos;
                }
                else
                {
                    List<Entity.Establecimiento> listadoEstablecimientos = Session["ListaEstablecimientos"] as List<Entity.Establecimiento>;
                    listadoEstablecimientos.Add(entity);
                    Session["ListaEstablecimientos"] = listadoEstablecimientos;
                }

                //ControlStock.DAL.FacturaDAL.InsertarFactura(entity);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public JsonResult EliminarFicha(int idFicha)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idFicha;
            var lista = DAL.FichaClienteDAL.ObtenerFicha(filtro);

            DAL.FichaClienteDAL.EliminarFicha(idFicha);
            Entity.Bitacora bitacora = new Entity.Bitacora();
            bitacora.Usr_Id = SessionH.Usuario.Id;
            bitacora.Modulo = "Ficha cliente";
            bitacora.Detalle = "Se elimina la ficha " + idFicha;
            DAL.BitacoraDAL.InsertarBitacora(bitacora);

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult UploadFiles(int id, int tiarId, string observacion)
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
                        string filename = Path.GetFileName(Request.Files[i].FileName);
                        var extension = Path.GetExtension(Request.Files[i].FileName);

                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        var guid = Guid.NewGuid().ToString() + extension;
                        fname = Path.Combine(Server.MapPath("/Uploads/"), guid);
                        file.SaveAs(fname);

                        Entity.Archivo archivo = new Entity.Archivo();
                        archivo.Ruta = guid;
                        archivo.Nombre = file.FileName;
                        archivo.FichId = id;
                        archivo.TiarId = tiarId;
                        archivo.Observacion = observacion;
                        DAL.ArchivoDAL.InsertarArchivo(archivo);

                        //Entidades.Asociacion asociacion = Session["Asociacion"] as Entidades.Asociacion;
                        //DAL.Asociacion.Adjunta(asociacion.ProdId, asociacion.ClieId, "/Images/Uploads/" + guid);
                    }


                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        public JsonResult ObtenerArchivos(int id)
        {
            var lista = DAL.ArchivoDAL.ObtenerArchivo(new Entity.Filtro() { Id = id });


            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerTipoArchivo()
        {
            Entity.Filtro filtro = new Entity.Filtro();
            var lista = DAL.TipoArchivoDAL.ObtenerTipoArchivo(filtro);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult EditarFicha(int idFicha)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idFicha;
            var lista = DAL.FichaClienteDAL.ObtenerFicha(filtro);

            Session["IdConsulta"] = idFicha;

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerEstablecimientos()
        {
            var idFicha = int.Parse(Session["IdConsulta"].ToString());
            var lista = DAL.EstablecimientoDAL.ObtenerEstablecimientos(new Entity.Filtro() { Ficha_Cliente_Id = idFicha });


            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}