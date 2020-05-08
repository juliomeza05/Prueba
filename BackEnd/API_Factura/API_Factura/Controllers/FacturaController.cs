using Entidades;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_Factura.Controllers
{
    [RoutePrefix("api/Factura")]
    [EnableCors(origins:"*", headers:"*",methods:"*")]
    public class FacturaController : ApiController
    {

        //Metodo que calcula el total de las factura
        
        [HttpGet]
        [Route("ObtenerProductos")]
        public IHttpActionResult obtenerTodosProductos()
        {
            HttpResponseMessage response = null;
            List<Producto> productos = null;
            string msm = "";
            try
            {
                productos = new ProductoDL().obtenerProductos();
                response = Request.CreateResponse(HttpStatusCode.OK);
                msm = JsonConvert.SerializeObject(productos);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                msm = "Fallo La consulta de registro!";
            }
            response.Content = new StringContent(msm, System.Text.Encoding.UTF8, "application/json");
            return ResponseMessage(response);
        }
        [HttpGet]
        [Route("ObtenerProducto")]
        public IHttpActionResult obtenerTodosProducto([FromUri] string id)
        {
            HttpResponseMessage response = null;
            Producto producto = null;
            string msm = "";
            try
            {
                producto = new ProductoDL().obtenerProducto(id);
                response = Request.CreateResponse(HttpStatusCode.OK);
                msm = JsonConvert.SerializeObject(producto);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                msm = "Fallo La consulta de registro!";
            }
            response.Content = new StringContent(msm, System.Text.Encoding.UTF8, "application/json");
            return ResponseMessage(response);
        }
        [HttpPost]
        [Route("Insertar")]
        public IHttpActionResult insertarProduco(Producto producto)
        {
            HttpResponseMessage response = null;
            string msm = "";
            try
            {
                new ProductoDL().insertarProducto(producto);
                response = Request.CreateResponse(HttpStatusCode.OK);
                msm = "Registro Exitoso!";
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                msm = "Fallo el registro";
            }
            response.Content = new StringContent(JsonConvert.SerializeObject(msm), System.Text.Encoding.UTF8, "application/json");
            return ResponseMessage(response);
        }
        [HttpPut]
        [Route("Actualizar")]
        public IHttpActionResult actualizarProducto(Producto producto)
        {
            HttpResponseMessage response = null;
            string msm = "";
            try
            {
                new ProductoDL().modificarProducto(producto);
                response = Request.CreateResponse(HttpStatusCode.OK);
                msm = "Registro Actualizado!";
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                msm = "Fallo el actualizar : " + ex.Message;
            }
            response.Content = new StringContent(JsonConvert.SerializeObject(msm), System.Text.Encoding.UTF8, "application/json");
            return ResponseMessage(response);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IHttpActionResult eliminarProducto([FromUri] string id)
        {
            HttpResponseMessage response = null;
            string msm = "";
            try
            {
                new ProductoDL().eliminarProducto(id);
                response = Request.CreateResponse(HttpStatusCode.OK);   
                msm = "Registro Eliminado!";
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                msm = "Fallo el Eliminar : " + ex.Message;
            }
            response.Content = new StringContent(JsonConvert.SerializeObject(msm), System.Text.Encoding.UTF8, "application/json");
            return ResponseMessage(response);
        }

        [HttpPost]
        [Route("CalcularFactura")]
        public Factura calculaFactura([FromBody] Factura factura) {

            if (factura != null)
            {
                foreach (Item item in factura.item)
                {
                    item.valorTotal = item.cantidad * item.producto.valor;
                }
                factura.valorTotal = factura.item.Sum(x => x.valorTotal);
            }
           

            return factura;
        }
    }
}
