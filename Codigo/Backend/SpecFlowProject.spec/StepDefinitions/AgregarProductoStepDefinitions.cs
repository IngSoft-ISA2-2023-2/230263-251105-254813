using PharmaGo.Domain.Entities;
using PharmaGo.WebApi.Controllers;
using PharmaGo.Domain.Entities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.spec.StepDefinitions
{

    [Binding]
    public class AgregarProductoStepDefinitions
    {
        private readonly Product _product = new Product();

        [Given(@"que ingreso ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" y ""([^""]*)"" correctamente")]
        public void GivenQueIngresoYCorrectamente(string codigo, string nombre, string descripcion, string precio)
        {
            throw new PendingStepException();
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
