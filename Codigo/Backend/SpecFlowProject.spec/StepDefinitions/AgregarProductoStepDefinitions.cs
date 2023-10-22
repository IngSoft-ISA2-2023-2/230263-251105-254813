using PharmaGo.BusinessLogic;
using PharmaGo.Domain.Entities;
using PharmaGo.WebApi.Controllers;

using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.spec.StepDefinitions
{

    [Binding]
    public class AgregarProductoStepDefinitions
    {
        private readonly ProductManager _productManager = new ProductManager();
        private readonly Product _producto = new Product();
        private ProductController _productController = new ProductController();
        private int _resultScenarioOne = 1;

        [Given(@"que estoy logueado como empleado, ingreso ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" y ""([^""]*)"" correctamente")]
        public void GivenQueEstoyLogueadoComoEmpleadoIngresoYCorrectamente(int codigo, string nombre, string descripcion, float precio)
        {
            _producto.Code = codigo;
            _producto.Name = nombre;
            _producto.Description = descripcion;
            _producto.Prize = precio;
        }

        [Given(@"deseo dar de alta un ""([^""]*)"", como ""([^""]*)""""")]
        public void GivenDeseoDarDeAltaUnComo(Product producto, string empleado)
        {
            _productManager.CreateProduct(empleado, producto);
        }



        [When(@"hago click en el botón agregar")]
        public void WhenHagoClickEnElBotonAgregar()
        {
            //El boton deberia llamar al controlador de creacion del producto?
            _productController.PostProduct();
        }

        [Then(@"el producto se agrega a la lista de productos")]
        public void ThenElProductoSeAgregaALaListaDeProductos()
        {
            _productManager.AddProduct();
            _resultScenarioOne.Should().Be(_productManager.Products.Count);
        }

    }
}
