using PharmaGo.BusinessLogic;
using PharmaGo.Domain.Entities;
using PharmaGo.IBusinessLogic;
using PharmaGo.WebApi.Controllers;
using PharmaGo.WebApi.Models.In;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.spec.StepDefinitions
{

    [Binding]
    public class AgregarProductoStepDefinitions
    {
        private readonly IProductManager _productManager;
        private readonly Product _producto = new Product();
        private ProductController _productController;
        private int _resultScenarioOne = 1;

        public AgregarProductoStepDefinitions(IProductManager manager, ProductController controller)
        {
            _productManager = manager;
            _productController = controller;
        }

        //Escenario 1
        [Given(@"Ingreso de ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" y ""([^""]*)"" correctamente")]
        public void GivenQueEstoyLogueadoComoEmpleadoIngresoYCorrectamente(int codigo, string nombre, string descripcion, decimal precio)
        {
            _producto.Code = codigo;
            _producto.Name = nombre;
            _producto.Description = descripcion;
            _producto.Price = precio;
        }

        [Given(@"deseo dar de alta un ""([^""]*)"", como ""([^""]*)""""")]
        public void GivenDeseoDarDeAltaUnComo(Product producto, string empleado)
        {
            _productManager.CreateProduct(producto, empleado);
        }

        [When(@"hago click en el botón agregar")]
        public void WhenHagoClickEnElBotonAgregar()
        {
            //El boton deberia llamar al controlador de creacion del producto?
            ProductModel productModel = new ProductModel();
            _productController.PostProduct(productModel);
        }

        [Then(@"el producto se agrega a la lista de productos")]
        public void ThenElProductoSeAgregaALaListaDeProductos()
        {
            Product product = new Product();
            string tokenEmployee = string.Empty;
            _productManager.CreateProduct(product, tokenEmployee);
            //_resultScenarioOne.Should().Be(_productManager.Products.Count);
            _resultScenarioOne.Should().Be(0);
        }

        //Escenario 2

        [Given(@"Dado que ingreso ""([^""]*)"" e ingreso ""([^""]*)"", ""([^""]*)"" y ""([^""]*)"" correctamente")]
        public void GivenDadoQueIngresoEIngresoYCorrectamente(int codigo, string nombre, string descripcion, decimal precio)
        {
            _producto.Code = codigo;
            _producto.Name = nombre;
            _producto.Description = descripcion;
            _producto.Price = precio;
        }


        [Then(@"salta un mensaje de error")]
        public void ThenSaltaUnMensajeDeError()
        {
            throw new PendingStepException();
        }

        [Then(@"el producto no se agrega a la lista")]
        public void ThenElProductoNoSeAgregaALaLista()
        {
            Product product = new Product();
            string tokenEmployee = string.Empty;
            _productManager.CreateProduct(product, tokenEmployee);
            //_resultScenarioOne.Should().Be(_productManager.Products.Count);
            _resultScenarioOne.Should().Be(0);
        }


    }
}
