using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Usuario()
        {
            return View();
        }
        public ActionResult InicioSesion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InicioSesion(ML.Usuario usuario){

            string UserName = usuario.UserName;
            string Password = usuario.Password;

            ML.Result result = BL.Usuario.GetUserName(UserName, Password);
            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;
                if(usuario.Password == Password)
                {
                    Session["IdUsuario"] = usuario.IdUsuario;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.valido = true;
                    ViewBag.Mensaje = "Error contraseña incorrecta";
                }
            }
            else
            {
                ViewBag.valido = true;
                ViewBag.Mensaje = "Error usuario incorrecto";
            }
            return PartialView("Modal");
        }
    }
}