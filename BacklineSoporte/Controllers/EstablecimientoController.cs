using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;


namespace BacklineSoporte.Controllers
{
    public class EstablecimientoController : Controller
    {
        // GET: Establecimiento
        public ActionResult Index(int id)
        {
            Models.EstablecimientosModel modelo = new Models.EstablecimientosModel();
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Ficha_Cliente_Id = id;
            Session["idFichaCliente"] = id;
            modelo.listaEstablecimientos = DAL.EstablecimientoDAL.ObtenerEstablecimientos(filtro);
            return View(modelo);
        }
        public JsonResult EliminarEstablecimiento(int id)
        {
            //Entity.Filtro filtro = new Entity.Filtro();
            //filtro.Id = idModulo;
            //var lista = DAL.EstablecimientoDAL.ObtenerModulos(filtro);

            DAL.EstablecimientoDAL.EliminarEstablecimiento(id);

            //Entity.Bitacora bitacora = new Entity.Bitacora();
            //bitacora.Usr_Id = SessionH.Usuario.Id;
            //bitacora.Modulo = "Mantenedor de modulos";
            //bitacora.Detalle = "Se elimina el modulo " + lista[0].ModuloStr;
            //DAL.BitacoraDAL.InsertarBitacora(bitacora);
            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GuardarEstablecimiento(BacklineSoporte.Entity.Establecimiento establecimiento)
        {
            
            establecimiento.Fich_Id = int.Parse(Session["idFichaCliente"].ToString());
            DAL.EstablecimientoDAL.InsertarEstablecimiento(establecimiento);

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }



        public JsonResult EditarEstablecimiento(int idEstablecimiento)
        {
            Entity.Filtro filtro = new Entity.Filtro();
            filtro.Id = idEstablecimiento;
  
         
            var lista = DAL.EstablecimientoDAL.ObtenerEstablecimientos(filtro);

            if (lista.Count == 1)
            {

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista[0], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = "noexiste", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}