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
            var _getResponsaveis = new UsuarioController().GetUsuarios().Where(x => x.TipoUsuario.Contains("Sindico") || x.TipoUsuario.Contains("Zelador"));
            ViewBag.Responsaveis = new SelectList(_getResponsaveis, "Nome", "Nome");

            return View();
        }

        public ActionResult Usuario()
        {
            List<string> ListTipoUsuario = new List<string>();
            ListTipoUsuario.Add("Morador");
            ListTipoUsuario.Add("Sindico - Responsavel");
            ListTipoUsuario.Add("Administradora - Responsavel");
            ListTipoUsuario.Add("Zelador - Responsavel");

            ViewBag.TipoUsuario = new SelectList(ListTipoUsuario);

            return View();
        }

        public ActionResult Assunto()
        {
            return View();
        }

        public ActionResult Comunicado()
        {
            var _getUsuarios = new UsuarioController().GetUsuarios().Where(x => x.TipoUsuario.Contains("Morador"));
            var _getResponsaveis = new UsuarioController().GetUsuarios().Where(x => x.TipoUsuario.Contains("Sindico") || x.TipoUsuario.Contains("Zelador"));            
            var _getAdministradoras = new UsuarioController().GetUsuarios().Where(x => x.TipoUsuario.Contains("Administradora"));
            var _getAssuntos = new AssuntoController().GetAssuntoEntities();

            ViewBag.NomeUsuarios = new SelectList(_getUsuarios, "Nome", "Nome");
            ViewBag.EmailResponsaveis = new SelectList(_getResponsaveis, "Email", "Email");
            ViewBag.EmailAdministradoras = new SelectList(_getAdministradoras, "Email", "Email");
            ViewBag.TipoUsuarios = new SelectList(_getUsuarios, "Id", "TipoUsuario");
            ViewBag.TipoAssunto = new SelectList(_getAssuntos, "TipoAssunto", "TipoAssunto");

            return View();
        }
    }
}
