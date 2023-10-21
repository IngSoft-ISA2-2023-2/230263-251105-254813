using PharmaGo.BusinessLogic;
using PharmaGo.Domain.Entities;

namespace SpecFlowProject.specs.StepDefinitions
{

    [Binding]
    public sealed class AddProductStepDefinitions
    {
        private readonly ProductManager _productM = new ProductManager();

        [Given(@"que ingreso ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" y ""([^""]*)"" correctamente")]
        public void GivenQueIngresoYCorrectamente(string codigo, string nombre, string descripcion, string precio)
        {
            _productM.Create(codigo, nombre, descripcion, precio)
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