using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace BacklineSoporte.Controllers
{
    public class CompletarVentaController : Controller
    {
        // GET: CompletarVenta
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ObtenerEmpresas()
        {
            var lista = DAL.EmpresaDAL.ObtenerEmpresas();

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerBodegas(Entity.Filtro entity)
        {
            var lista = DAL.BodegaDAL.ObtenerBodegas(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerProductos(Entity.Filtro entity)
        {
            var lista = DAL.ProductoDAL.ObtenerProductos(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult ObtenerRlEmpBode(Entity.Filtro entity)
        {
            if (entity.Prod_Id <= 0)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            var lista = DAL.RL_EMP_BODE_DAL.ObtenerRlEmpBode(entity);

            if (lista == null || lista.Count == 0)
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "Error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return new JsonResult() { ContentEncoding = Encoding.Default, Data = lista, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult AgregarProducto(Entity.RL_EMP_BODE entity)
        {
            try
            {
                if (Session["ListaProductos"] == null)
                {
                    List<Entity.RL_EMP_BODE> listadoProductos = new List<Entity.RL_EMP_BODE>();
                    listadoProductos.Add(entity);
                    Session["ListaProductos"] = listadoProductos;
                }
                else
                {
                    List<Entity.RL_EMP_BODE> listadoProductos = Session["ListaProductos"] as List<Entity.RL_EMP_BODE>;
                    listadoProductos.Add(entity);
                    Session["ListaProductos"] = listadoProductos;
                }

                //ControlStock.DAL.FacturaDAL.InsertarFactura(entity);
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public JsonResult InsertarDescuentoStock(Entity.RL_EMP_BODE entity)
        {
            try
            {
                List<Entity.RL_EMP_BODE> listadoProductos = Session["ListaProductos"] as List<Entity.RL_EMP_BODE>;

                foreach (var detalle in listadoProductos)
                {

                    var idFdet = DAL.RL_EMP_BODE_DAL.InsertarFdet(detalle);

                }

                Entity.Filtro filtro = new Entity.Filtro();
                filtro.Fact_Id = entity.Fact_Id;
                var factura = DAL.FacturaDAL.ObtenerFactura(filtro);

                entity.Usr_Id = factura[0].Usr_Id;
                entity.Fecha_Movimiento = factura[0].FechaMovimiento;
                entity.Cont_Id = factura[0].Cont_Id;
                entity.Observacion = "Dispensar Medicamento:" + factura[0].RutPaciente + " " + factura[0].Paciente.Trim() + " " + "N°Disp.:" + factura[0].NumeroVenta;
                var idAjusteBodega = DAL.RL_EMP_BODE_DAL.InsertarAjusteBodega(entity);

                foreach (var detalle in listadoProductos)
                {
                    detalle.Ajuste_Bodega_Id = idAjusteBodega.Id;
                    var idFdet = DAL.RL_EMP_BODE_DAL.InsertarRLAjusteProd(detalle);

                    detalle.Emp_Id = entity.Emp_Id;
                    detalle.Bode_Id = entity.Bode_Id;
                    DAL.RL_EMP_BODE_DAL.DescontarStock(detalle);
                }


                Session["ListaProductos"] = new List<Entity.RL_EMP_BODE>();

                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "exito", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception ex)
            {
                return new JsonResult() { ContentEncoding = Encoding.Default, Data = "error", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
    }
}