using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace BacklineSoporte.Controllers
{
    public class ImagenesDesarrolloController : Controller
    {
        // GET: ImagenesDesarrollo
        public ActionResult Index(int id)
        {
            BacklineSoporte.Models.ImagenesDesarrolloModel modelo = new Models.ImagenesDesarrolloModel();
            BacklineSoporte.Entity.Filtro filtro = new BacklineSoporte.Entity.Filtro();
            filtro.Desarrollo_Id = id;
            Session["idDesarrollo"] = id;
            modelo.listaImagenDesarrollo = BacklineSoporte.DAL.ImagenDesarrolloDAL.ObtenerImagenesDesarrollo(filtro);
            modelo.IdDesarrollo = id;
            return View(modelo);
        }
        public JsonResult SaveImagenDesarrollo(BacklineSoporte.Entity.ImagenDesarrollo entity)
        {
            try
            {
                entity.Desarrollo_Id = int.Parse(Session["idDesarrollo"].ToString());
                SaveImagen(entity);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }
        public void SaveImagen(BacklineSoporte.Entity.ImagenDesarrollo entity)
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
                BacklineSoporte.DAL.ImagenDesarrolloDAL.InsertarImagenDesarrollo(entity);

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
