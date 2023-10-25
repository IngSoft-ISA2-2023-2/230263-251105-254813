using NUnit.Framework;
using PharmaGo.Domain.Entities;
using PharmaGo.IBusinessLogic;
using PharmaGo.BusinessLogic;
using PharmaGo.WebApi.Controllers;
using PharmaGo.WebApi.Models.In;
using PharmaGo.WebApi.Models.Out;
using System;
using TechTalk.SpecFlow;
using Moq;
using BoDi;
using PharmaGo.DataAccess.Repositories;
using PharmaGo.IDataAccess;
using PharmaGo.DataAccess;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace SpecFlowProject.spec.StepDefinitions
{
    [Binding]
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
        private readonly Product _product = new Product();
        private readonly ProductModelResponse _result;
        private ProductController _productController;
        private int _resultScenarioOne = 1;
        private Exception _exception;

        public AgregarProductoStepDefinitions(IProductManager productManager, ProductController controller)
        {
            _productManager = SpecFlowContextUtils.GetProductManager();
            _productController = controller;
        }


        [Given(@"que ingreso codigo is (.*)")]
        public void GivenQueIngresoCodigoIs(int p0)
        {
            _product.Code = p0;
        }

        [Given(@"ingreso nombre is ""([^""]*)""")]
        public void GivenIngresoNombreIs(string shampoo)
        {
            _product.Name = shampoo;
        }

        [Given(@"ingreso descripcion is ""([^""]*)""")]
        public void GivenIngresoDescripcionIs(string p0)
        {
            _product.Description = p0;
        }


        [Given(@"ingreso precio is (.*)")]
        public void GivenIngresoPrecioIs(Decimal p0)
        {
            _product.Price = p0;
        }

        [When(@"hago click en el botón agregar")]
        public void WhenHagoClickEnElBotonAgregar()
        {
            try
            {
                ProductModel productModel = new ProductModel
                {
                    Name = _product.Name,
                    Description = _product.Description,
                    Code = _product.Code,
                    Prize = _product.Price
                };
                _productController.PostProduct(productModel);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"muestra el mensaje Agregado")]
        public void ThenMuestraElMensajeAgregado()
        {
            Assert.IsTrue(true);
        }

    }
}
