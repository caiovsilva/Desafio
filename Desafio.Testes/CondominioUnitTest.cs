using System.Web.Http;
using System.Web.Http.Results;
using DesafioWebApplication.Controllers;
using DesafioWebApplication.Models.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Desafio.Testes
{
    [TestClass]
    public class CondominioUnitTest
    {
        [TestMethod]
        public void GetCondominioByIdSucces()
        {
            var controller = new CondominioController();

            var response = controller.GetCondominioEntity(1);
            var contentResult = response as OkNegotiatedContentResult<CondominioEntity>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetAdminstradoraNotFound()
        {
            var controller = new CondominioController();

            IHttpActionResult actionResult = controller.GetCondominioEntity(100);

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddCondominioTest()
        {
      
            var controller = new CondominioController();
            var Condominio = new CondominioEntity
            {
                NomeCondominio = "Condominio UnitTest",
                Administradora = "Administrador UniTest",
                Responsavel = "Responsável UnitTest",
            };

            IHttpActionResult actionResult = controller.PostCondominioEntity(Condominio);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<CondominioEntity>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public void UpdateCondominioTest()
        {
            var controller = new CondominioController();
            var Condominio = new CondominioEntity
            {
                Id = 1,
                NomeCondominio = "Update Condominio UnitTest",
                Administradora = "Update Administrador UniTest",
                Responsavel = "Update Responsável UnitTest",
            };

            IHttpActionResult actionResult = controller.PutCondominioEntity(Condominio.Id, Condominio);
            var contentResult = actionResult as NegotiatedContentResult<CondominioEntity>;
            Assert.IsNull(contentResult);

        }
    }
}
