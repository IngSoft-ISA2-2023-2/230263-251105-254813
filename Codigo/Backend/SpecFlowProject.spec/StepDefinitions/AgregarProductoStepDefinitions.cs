using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PharmaGo.DataAccess.Repositories;
<<<<<<< HEAD
using PharmaGo.IDataAccess;
using PharmaGo.DataAccess;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
=======
using PharmaGo.Domain.Entities;
using PharmaGo.WebApi.Models.In;
using System;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
>>>>>>> main

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TechTalk.SpecFlow;




namespace SpecFlowPharmaGo.WebApi.StepDefinitions
{
    [Binding]
<<<<<<< HEAD
    public sealed class RegistrationHooks
    {
        [BeforeTestRun]
        public static void RegisterTestThreadDependencies(TestThreadContext testThreadContext)
        {
            testThreadContext.TestThreadContainer.RegisterTypeAs<ProductManager, IProductManager>();
            var productRepositoryMock = new Mock<IRepository<Product>>();
            productRepositoryMock.Setup(repo => repo.Exists(It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns((Expression<Func<Product, bool>> expression) => new List<Product>().Any(expression.Compile()));
            testThreadContext.TestThreadContainer.RegisterInstanceAs(productRepositoryMock.Object);
            var sessionRepositoryMock = new Mock<IRepository<Session>>();
            sessionRepositoryMock.Setup(repo => repo.Exists(It.IsAny<Expression<Func<Session, bool>>>()))
                .Returns((Expression<Func<Session, bool>> expression) => new List<Session>().Any(expression.Compile()));
            testThreadContext.TestThreadContainer.RegisterInstanceAs(sessionRepositoryMock.Object);
            var sessions = new List<Session>();

            var sessionDbSetMock = new Mock<DbSet<Session>>();
            sessionDbSetMock.As<IQueryable<Session>>().Setup(m => m.Provider).Returns(sessions.AsQueryable().Provider);
            sessionDbSetMock.As<IQueryable<Session>>().Setup(m => m.Expression).Returns(sessions.AsQueryable().Expression);
            sessionDbSetMock.As<IQueryable<Session>>().Setup(m => m.ElementType).Returns(sessions.AsQueryable().ElementType);
            sessionDbSetMock.As<IQueryable<Session>>().Setup(m => m.GetEnumerator()).Returns(sessions.AsQueryable().GetEnumerator());

            var dbContextMock = new Mock<PharmacyGoDbContext>();
            dbContextMock.Setup(db => db.Set<Session>()).Returns(sessionDbSetMock.Object);

            testThreadContext.TestThreadContainer.RegisterInstanceAs(dbContextMock.Object);
        }
    }

    [Binding]
    public class AgregarProductoStepDefinitions
    {
        private readonly IProductManager _productManager;
=======
    public class InsertProductStepDefinitions
    {



        private readonly ScenarioContext context;
>>>>>>> main
        private readonly Product _product = new Product();
        private readonly ProductModel _productModel = new ProductModel();
        public InsertProductStepDefinitions(ScenarioContext context)
        {
<<<<<<< HEAD
            _productManager = SpecFlowContextUtils.GetProductManager();
            _productController = controller;
=======
            this.context = context;
>>>>>>> main
        }



        [Given(@"the name product(.*) of the product")]
        public void GivenTheNameProductOfTheProduct(string name)
        {
            _product.Name = name;
            _productModel.Name = name;
        }



        [Given(@"the description(.*) of the product")]
        public void GivenTheDescriptionNewExcerciseBallOfTheProduct(string description)
        {
            _product.Description = description;
            _productModel.Description = description;
        }

<<<<<<< HEAD
        [When(@"hago click en el botón agregar")]
        public void WhenHagoClickEnElBotonAgregar()
=======




        [Given(@"the code (.*) of the product")]
        public void GivenTheCodeOfTheProduct(int code)
>>>>>>> main
        {
            _product.Code = code;
            _productModel.Code = code;
        }



        [Given(@"the price (.*) of the product")]
        public void GivenThePriceOfTheProduct(decimal price)
        {
            _product.Price = price;
            _productModel.Prize = price;
        }



        [When(@"a user wants to add it to the system")]
        public async Task WhenAUserWantsToAddItToTheSystemAsync()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Add("Authorization", "e9e0e1e9-3812-4eb5-949e-ae92ac931401");



            for (var i = 0; i < 20; i++)
            {
                var request1 = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7186/api/products/{i}");
                var response1 = await client.SendAsync(request1).ConfigureAwait(false);



            }
            string requestBody = JsonConvert.SerializeObject(_productModel);



            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7186/api/products");



            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");



            var response = await client.SendAsync(request).ConfigureAwait(false);



            try
            {
<<<<<<< HEAD
                ProductModel productModel = new ProductModel
                {
                    Name = _product.Name,
                    Description = _product.Description,
                    Code = _product.Code,
                    Prize = _product.Price
                };
                _productController.PostProduct(productModel);
=======
                context.Set(response.StatusCode, "ResponseStatusCode");
>>>>>>> main
            }
            finally
            {
            }
        }



        [Then(@"add the product to the user´s pharmacy and return the  product model")]
        public void ThenAddTheProductToTheUserSPharmacyAndReturnTheProductModel()
        {
            Assert.AreEqual(200, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
        }






    }
}