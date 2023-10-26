using PharmaGo.Domain.Entities;
using PharmaGo.WebApi.Models.In;
using System;
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
        [Given(@"ingresamos el nombre desodorante(.*) del producto a modificar")]
        public void GivenIngresamosElNombreDesodoranteDelProductoAModificar(string nombre)
        {
            throw new PendingStepException();
        }

        [Given(@"ingresamos la descripcion Es para el cuerpo(.*) del producto a modificar")]
        public void GivenIngresamosLaDescripcionEsParaElCuerpoDelProductoAModificar(string descripcion)
        {
            throw new PendingStepException();
        }

        [Given(@"ingresamos el codigo (.*) del producto a modificar")]
        public void GivenIngresamosElCodigoDelProductoAModificar(int codigo)
        {
            throw new PendingStepException();
        }

        [Given(@"ingresamos el precio (.*) del producto a modificar")]
        public void GivenIngresamosElPrecioDelProductoAModificar(decimal price)
        {
            throw new PendingStepException();
        }

        [When(@"hago click en el botón modificar")]
        public void WhenHagoClickEnElBotonModificar()
        {
            throw new PendingStepException();
        }

        [Then(@"se modifica exitosamente")]
        public void ThenSeModificaExitosamente()
        {
            throw new PendingStepException();
        }
    }
}
