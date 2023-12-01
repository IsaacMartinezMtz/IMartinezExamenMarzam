using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        [HttpGet]
        public ActionResult Form()
        {
            int IdUsuario = Convert.ToInt16(Session["IdUsuario"]);
            ML.Result result = BL.Medicamento.GetAll( IdUsuario);
            if (result.Correct)
            {
                ML.Medicamento medicamento = new ML.Medicamento();
                medicamento.Mediacementos = result.Objects;
                
                return View(medicamento);
            }
            return View();
        }
    }
}