using System;
using System.Web.Http;
using System.Web.Http.Results;
using DesafioWebApplication.Controllers;
using DesafioWebApplication.Models.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesafioTestes
{
    [TestClass]
    public class UsuarioUnitTest
    {
        [TestMethod]
        public void GetUsuarioByIdSucces()
        {
            var controller = new UsuarioController();

            var response = controller.GetUsuarioEntity(1);
            var contentResult = response as OkNegotiatedContentResult<UsuarioEntity>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetAdminstradoraNotFound()
        {
            var controller = new UsuarioController();

            IHttpActionResult actionResult = controller.GetUsuarioEntity(100);

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddUsuarioTest()
        {

            var controller = new UsuarioController();
            var Usuario = new UsuarioEntity
            {
                Nome = "Usuario UnitTest",
                Email = "Email UnitTest",
                Condominio = "Condominio UnitTest",
                TipoUsuario = "TipoUsuarioUnitTest",
            };

            IHttpActionResult actionResult = controller.PostUsuarioEntity(Usuario);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<UsuarioEntity>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public void UpdateUsuarioTest()
        {
            var controller = new UsuarioController();
            var Usuario = new UsuarioEntity
            {
                Id = 3,
                Nome = "Update Usuario UnitTest",
                Email = "Update Email UnitTest",
                Condominio = "Update Condominio UnitTest",
                TipoUsuario = "Update TipoUsuarioUnitTest",
            };

            IHttpActionResult actionResult = controller.PutUsuarioEntity(Usuario.Id, Usuario);
            var contentResult = actionResult as NegotiatedContentResult<UsuarioEntity>;
            Assert.IsNull(contentResult);

        }
    }
}
