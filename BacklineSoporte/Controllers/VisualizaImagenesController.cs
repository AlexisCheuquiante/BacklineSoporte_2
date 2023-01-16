using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace BacklineSoporte.Controllers
{
    public class VisualizaImagenesController : Controller
    {
        // GET: VisualizaImagenes
        public ActionResult Index(int id)
        {
            BacklineSoporte.Models.VisualizadorModel modelo = new Models.VisualizadorModel();
            BacklineSoporte.Entity.Filtro filtro = new BacklineSoporte.Entity.Filtro();
            filtro.RequeId = id;
            Session["idRequerimiento"] = id;
            modelo.ListaImagenes = BacklineSoporte.DAL.ImagenDAL.ObtenerImagenes(filtro);
            modelo.IdRequerimiento = id;
            return View(modelo);
        }
        public JsonResult SaveImagenProblema(BacklineSoporte.Entity.Imagen entity)
        {
            try
            {
                entity.RequeId = int.Parse(Session["idRequerimiento"].ToString());
                SaveImagen(entity);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public void SaveImagen(BacklineSoporte.Entity.Imagen entity)
        {
            try
            {
                var extension = Path.GetExtension(entity.NOMBRE_IMAGEN);
                byte[] imageBytes = Convert.FromBase64String(entity.RUTA_IMAGEN.Replace("data:image/jpeg;base64,", "").Replace("data:image/png;base64,", "").Replace("data:image/gif;base64,", ""));

                var ruta = "/Recursos/Imagenes/Uploads/" + Guid.NewGuid().ToString() + extension;
                entity.RUTA_IMAGEN = ruta;
                System.IO.FileStream stream = new FileStream(System.Web.HttpContext.Current.Server.MapPath(ruta), FileMode.CreateNew);
                System.IO.BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(imageBytes, 0, imageBytes.Length);
                writer.Close();

                //string pathThumbs = System.Web.HttpContext.Current.Server.MapPath(ruta);
                //pathThumbs = "/Images/ThumbProductos/" + CreateThumb(pathThumbs);
                //entity.RUTA_IMAGEN_THUMB = pathThumbs;
                BacklineSoporte.DAL.ImagenDAL.InsertarImagenRequerimiento(entity);

                //validator.AddValidationSuccess("La información del camión fué guardada exitosamente.");
            }
            catch (Exception ex)
            {
                // validator.AddValidationError(ex.Message);
            }
            finally
            {
                // validator.EndValidation();
            }

            // return validator;
        }
    }
}