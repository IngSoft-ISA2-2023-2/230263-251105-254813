using Newtonsoft.Json;
using NUnit.Framework;
using PharmaGo.WebApi.Models.In;
using System;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class DeleteProductStepDefinitions
    {
        private readonly ScenarioContext context;
        private int productId;
        private Exception _exception;
        public DeleteProductStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"estoy logueado como empleado e ingreso un codigo (.*) de un producto existente")]
        public void GivenEstoyLogueadoComoEmpleadoEIngresoUnCodigoDeUnProductoExistente(int p0)
        {
            this.productId = p0;
        }

        [When(@"hago click en el botón eliminar")]
        public async Task WhenHagoClickEnElBotonEliminar()
        {
            HttpClientHandler cliHandler = new HttpClientHandler();
            cliHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var cli = new HttpClient(cliHandler);
            cli.DefaultRequestHeaders.Add("Authorization", "E9E0E1E9-3812-4EB5-949E-AE92AC931401");
            var req = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7186/api/product/{23457}");
            var res = await cli.SendAsync(req).ConfigureAwait(false);
            try
            {
                context.Set(res.StatusCode, "ResponseStatusCode");
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"el producto se elimina de la lista de productos")]
        public void ThenElProductoSeEliminaDeLaListaDeProductos()
        {
            Assert.AreEqual(200, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
        }

        [Then(@"obtengo un mensaje de error")]
        public void ThenObtengoUnMensajeDeError()
        {
            Assert.AreEqual(400, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
        }
    }
}
