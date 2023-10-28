using Newtonsoft.Json;
using NUnit.Framework;
using PharmaGo.Domain.Entities;
using PharmaGo.WebApi.Models.In;
using PharmaGo.WebApi.Models.Out;
using System;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using static PharmaGo.WebApi.Models.In.PurchaseModelRequest;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class CreateProductPurchaseStepDefinitions
    {
        private readonly ScenarioContext context;
        private readonly Purchase _purchase = new Purchase();
        private readonly PurchaseModelRequest _purchaseModel = new PurchaseModelRequest();
        private PurchaseDetailModelRequest _purchaseDetailModelRequest = new PurchaseDetailModelRequest();

        private Exception _exception;
        public CreateProductPurchaseStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }
        [Given(@"se ingresa el email (.*) valido")]
        public void GivenSeIngresaElEmailValido(string email)
        {
            _purchase.BuyerEmail = email;
            _purchaseModel.BuyerEmail = email;
        }

        [Given(@"se ingresa la fecha (.*) valida")]
        public void GivenSeIngresaLaFechaValida(DateTime fecha)
        {
            _purchase.PurchaseDate = fecha;
            _purchaseModel.PurchaseDate = fecha;
        }

        [Given(@"se ingresa el codigo (.*) del producto valido")]
        public void GivenSeIngresaElCodigoDelProductoValido(int codigoProd)
        {
            _purchaseDetailModelRequest.CodeOfProduct = codigoProd;
        }

        [Given(@"se ingresa el id (.*) de la farmacia valido")]
        public void GivenSeIngresaElIdDeLaFarmaciaValido(int id)
        {
            _purchaseDetailModelRequest.PharmacyId = id;
        }

        [Given(@"se ingresa el codigo (.*) de la droga valido")]
        public void GivenSeIngresaElCodigoDeLaDrogaValido(string codigo)
        {
            _purchaseDetailModelRequest.Code = codigo;
        }

        [Given(@"se ingresa la cantidad (.*) de la droga valido")]
        public void GivenSeIngresaLaCantidadDeLaDrogaValido(int p0)
        {
           _purchaseDetailModelRequest.Quantity = p0;
        }

        [Given(@"se ingresa la cantidad (.*) del producto valido")]
        public void GivenSeIngresaLaCantidadDelProductoValido(int p0)
        {
            _purchaseDetailModelRequest.QuantityOfProduct = p0;
        }
        [When(@"hace click en el boton crear compra")]
        public async Task WhenHaceClickEnElBotonCrearCompra()
        {
            _purchaseModel.Details = new List<PurchaseDetailModelRequest> { _purchaseDetailModelRequest };
            HttpClientHandler cliHandler = new HttpClientHandler();
            cliHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var cli = new HttpClient(cliHandler);
            //cli.DefaultRequestHeaders.Add("Authorization", "E9E0E1E9-3812-4EB5-949E-AE92AC931401");
            string requestBody = JsonConvert.SerializeObject(_purchaseModel);
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7186/api/Purchases");
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

        [Then(@"se crea el producto de forma correcta")]
        public void ThenSeCreaElProductoDeFormaCorrecta()
        {
            Assert.AreEqual(200, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
        }

    }
}
