using DesafioWebApplication.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Condominio()
        {
            return View();
        }

        public ActionResult Usuario()
        {
            return View();
        }

        public ActionResult Assunto()
        {
            return View();
        }

        public ActionResult Comunicado()
        {
            var listUsuarios = new List<UsuarioEntity>();
            var _getUsuarios = new UsuarioController();

            ViewBag.NomeUsuarios = new SelectList(_getUsuarios.GetUsuarios(), "Id", "Nome");
            ViewBag.EmailUsuarios = new SelectList(_getUsuarios.GetUsuarios(), "Id", "Email");
            ViewBag.TipoUsuarios = new SelectList(_getUsuarios.GetUsuarios(), "Id", "TipoUsuario");

            var listAssuntos = new List<AssuntoEntity>();
            var _getAssuntos = new AssuntoController();

            ViewBag.TipoAssunto = new SelectList(_getAssuntos.GetAssuntoEntities(), "Id", "TipoAssunto");


            return View();
        }
    }
}
