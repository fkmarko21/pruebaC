using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoMarco.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Resgistrar(string nombre, string correo, string contraseña, string confirmarContraseña)
        {
            return View();
        }

        public ActionResult Login(string correo, string contraseña)
        {
            //Consulta a bd
            //Si el usuario existe
            Session["Usuario"] = correo; //igual al de bd
            return View();
        }
    }
}