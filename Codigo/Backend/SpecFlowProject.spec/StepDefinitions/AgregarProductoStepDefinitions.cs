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

        [Given(@"que ingreso ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" y ""([^""]*)"" correctamente")]
        public void GivenQueIngresoYCorrectamente(int codigo, string nombre, string descripcion, float precio)
        {
            Product product = new Product();
            product.Code = codigo;
            product.Name = nombre;
            product.Description = descripcion;
            product.Prize = precio;
            _productManager.CreateProduct(product);
        }

        [Given(@"deseo dar de alta un producto")]
        public void GivenDeseoDarDeAltaUnProducto()
        {
            throw new PendingStepException();
        }

        [When(@"hago click en el botón agregar")]
        public void WhenHagoClickEnElBotonAgregar()
        {
            throw new PendingStepException();
        }

        [Then(@"el producto se agrega a la lista de productos")]
        public void ThenElProductoSeAgregaALaListaDeProductos()
        {
            throw new PendingStepException();
        }
    }
}
