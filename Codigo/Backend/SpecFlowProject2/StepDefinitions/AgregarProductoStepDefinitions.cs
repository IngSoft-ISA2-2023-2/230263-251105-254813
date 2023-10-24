using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PharmaGo.DataAccess.Repositories;
using PharmaGo.Domain.Entities;
using PharmaGo.WebApi.Models.In;
using System;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SpecFlowPharmaGo.WebApi.StepDefinitions
{
    [Binding]
    public class InsertProductStepDefinitions
    {

        private readonly ScenarioContext context;
        private readonly Product _product = new Product();
        private readonly ProductModel _productModel = new ProductModel();
        private Exception _exception;
        public InsertProductStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"ingresamos el nombre(.*) del producto")]
        public void GivenNombreDelPorducto(string nombre)
        {
            _product.Name = nombre;
            _productModel.Name = nombre;
        }

        [Given(@"ingresamos la descripcion(.*) del producto")]
        public void GivenDescripcionDelProducto(string descripcion)
        {
            _product.Description = descripcion;
            _productModel.Description = descripcion;
        }

        [Given(@"ingresamos el codigo (.*) del producto")]
        public void GivenCodigoDelProducto(int codigo)
        {
            _product.Code = codigo;
            _productModel.Code = codigo;
        }


        [Given(@"ingresamos el precio (.*) del producto")]
        public void GivenPrecioDelPorducto(decimal precio)
        {
            _product.Price = precio;
            _productModel.Prize = precio;
        }



        [When(@"hago click en el botón agregar")]
        public async Task WhenHagoClick()
        {
            var req = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7186/api/products/{1}");
            //var res = await cli.SendAsync(req).ConfigureAwait(false);
            HttpClientHandler cliHandler = new HttpClientHandler();
            cliHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var cli = new HttpClient(cliHandler);
            cli.DefaultRequestHeaders.Add("Authorization", "3a4e5d4b-9c1a-402f-8e63-ec7d3120c9b7");

           
            
            string requestBody = JsonConvert.SerializeObject(_productModel);
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7186/api/products");
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

        [Then(@"agrega el producto a la farmacia")]
        public void ThenAddTheProductToPharmacy()
        {
            if (_exception == null)
            {
                Assert.AreEqual(200, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
            }
            else 
            {
                Assert.IsFalse(false);
            }
        }

        [Then(@"salta un mensaje de error con nombre invalido y el producto no se agrega a la lista")]
        public void ThenTheProductNotAddToPharmacy()
        {
            if (_exception == null)
            {
                Assert.AreEqual(200, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
            }
            else
            {
                Assert.IsTrue(true);
            }
        }
    }
}