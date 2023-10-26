using Newtonsoft.Json;
using NUnit.Framework;
using PharmaGo.Domain.Entities;
using PharmaGo.WebApi.Models.In;
using System;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class ModifyProductStepDefinitions
    {
        private readonly ScenarioContext context;
        private readonly Product _product = new Product();
        private readonly ProductModel _productModel = new ProductModel();
        private Exception _exception;
        public ModifyProductStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }
        [Given(@"ingresamos el nombre (.*) del producto a modificar")]
        public void GivenIngresamosElNombreDelProductoAModificar(string nombre)
        {
            _product.Name = nombre;
            _productModel.Name = nombre;
        }

        [Given(@"ingresamos la descripcion (.*) del producto a modificar")]
        public void GivenIngresamosLaDescripcionDelProductoAModificar(string descripcion)
        {
            _product.Description = descripcion;
            _productModel.Description = descripcion;
        }

        [Given(@"ingresamos el codigo (.*) del producto a modificar")]
        public void GivenIngresamosElCodigoDelProductoAModificar(int codigo)
        {
            _product.Code = codigo;
            _productModel.Code = codigo;
        }

        [Given(@"ingresamos el precio (.*) del producto a modificar")]
        public void GivenIngresamosElPrecioDelProductoAModificar(decimal price)
        {
            _product.Price = price;
            _productModel.Prize = price;
        }

        [When(@"hago click en el botón modificar")]
        public async Task WhenHagoClickEnElBotonModificarAsync()
        {
            HttpClientHandler cliHandler = new HttpClientHandler();
            cliHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var cli = new HttpClient(cliHandler);
            cli.DefaultRequestHeaders.Add("Authorization", "E9E0E1E9-3812-4EB5-949E-AE92AC931401");
            string requestBody = JsonConvert.SerializeObject(_productModel);
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7186/api/product/{1}");
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

        [Then(@"se modifica exitosamente")]
        public void ThenSeModificaExitosamente()
        {
            Assert.AreEqual(200, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
        }
    }
}
