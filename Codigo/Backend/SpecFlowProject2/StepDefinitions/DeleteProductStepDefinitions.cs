using Newtonsoft.Json;
using PharmaGo.WebApi.Models.In;
using System;
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

        [Given(@"estoy logueado como empleado e ingreso un identificador <identificador> de un producto existente")]
        public void GivenEstoyLogueadoComoEmpleadoEIngresoUnIdentificadorIdentificadorDeUnProductoExistente(int id)
        {
            this.productId = id;
        }


        [When(@"hago click en el botón eliminar")]
        public async Task WhenHagoClickEnElBotonEliminar()
        {
            HttpClientHandler cliHandler = new HttpClientHandler();
            cliHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var cli = new HttpClient(cliHandler);
            cli.DefaultRequestHeaders.Add("Authorization", "E9E0E1E9-3812-4EB5-949E-AE92AC931401");
            var req = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7186/api/product/{1}");
            var res = await cli.SendAsync(req).ConfigureAwait(false);
            //string requestBody = JsonConvert.SerializeObject(_productModel);
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7186/api/product");
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await cli.SendAsync(request).ConfigureAwait(false);
            try
            {
                context.Set(response.StatusCode, "ResponseStatusCode");
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"el producto se elimina de la lista de productos")]
        public void ThenElProductoSeEliminaDeLaListaDeProductos()
        {
            throw new PendingStepException();
        }

        [Then(@"obtengo un mensaje de error")]
        public void ThenObtengoUnMensajeDeError()
        {
            throw new PendingStepException();
        }
    }
}
