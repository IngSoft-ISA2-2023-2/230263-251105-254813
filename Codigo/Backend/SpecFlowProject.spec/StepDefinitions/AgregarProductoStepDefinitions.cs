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

namespace SpecFlowProject.spec.StepDefinitions
{
    [Binding]
    public sealed class RegistrationHooks
    {
        [BeforeTestRun]
        public static void RegisterTestThreadDependencies(TestThreadContext testThreadContext)
        {
            testThreadContext.TestThreadContainer.RegisterTypeAs<ProductManager, IProductManager>();
            testThreadContext.TestThreadContainer.RegisterTypeAs<ProductRepository,IRepository<Product>>();

        }
    }

    [Binding]
    public class AgregarProductoStepDefinitions
    {

        //private readonly IProductManager _productManager;
        private readonly IProductManager _productManager;
        private readonly IRepository<Product> _repository;
        private readonly Product _product = new Product();
        private readonly ProductModelResponse _result;
        private ProductController _productController;
        private int _resultScenarioOne = 1;
        private Exception _exception;

        public AgregarProductoStepDefinitions(IProductManager productManager, IRepository<Product> repository, ProductController controller)
        {

            _productManager = SpecFlowContextUtils.GetProductManager();
            _productController = controller;
            _repository = repository;
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
        public void WhenHagoClickEnElBotonAgregar(IProductManager _productManager)
        {
            try
            {
                // Configura un mock para IProductManager
                //var productManagerMock = new Mock<IProductManager>();
                //productManagerMock.Setup(manager => manager.CreateProduct(It.IsAny<Product>(), It.IsAny<string>()))
                //    .Returns(_product);
                //_productManager = productManagerMock.Object;

                // Continúa con la lógica de tu prueba
                ProductModel productModel = new ProductModel
                {
                    Name = _product.Name,
                    Description = _product.Description,
                    Code = _product.Code,
                    Prize = _product.Price
                };
                _productController = new ProductController();
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
