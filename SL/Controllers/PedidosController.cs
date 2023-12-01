using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/pedido")]
    public class PedidosController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Pedidos.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Pedidos pedidos)
        {
            ML.Result result = BL.Pedidos.PedidoAdd(pedidos);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("{idPedidos}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idPedidos)
        {
            ML.Result result =BL.Pedidos.PedidosDelete(idPedidos);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("{idPedidos}")]
        [HttpGet]
        public IHttpActionResult GetById(int idPedidos)
        {
            ML.Result result = BL.Pedidos.GetById(idPedidos);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("{idPedidos}")]
        [HttpPut]
        public IHttpActionResult Upadate(int idPedidos, [FromBody] ML.Pedidos pedidos){
            pedidos.IdPedido = idPedidos;
            ML.Result result = BL.Pedidos.PedidoUpdate(pedidos);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

    }
}
