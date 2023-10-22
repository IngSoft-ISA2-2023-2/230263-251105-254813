using NUnit.Framework;
using PharmaGo.BusinessLogic;
using PharmaGo.Domain.Entities;
using PharmaGo.IBusinessLogic;
using PharmaGo.WebApi.Controllers;
using PharmaGo.WebApi.Models.In;
using PharmaGo.WebApi.Models.Out;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.spec.StepDefinitions
{

    [Binding]
    public class AgregarProductoStepDefinitions
    {
        private readonly IProductManager _productManager;
        private readonly Product _product = new Product();
        private readonly ProductModelResponse _result;
        private ProductController _productController;
        private int _resultScenarioOne = 1;
        private Exception _exception;

        public AgregarProductoStepDefinitions(IProductManager manager, ProductController controller)
        {
            _productManager = manager;
            _productController = controller;
        }

        [Given(@"que ingreso ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" y ""([^""]*)""")]
        public void GivenQueIngresoY(int codigo, string nombre, string descripcion, decimal precio)
        {
            _product.Code = codigo;
            _product.Name = nombre;
            _product.Description = descripcion;
            _product.Price = precio;
        }

        [When(@"hago click en el botón agregar")]
        public void WhenHagoClickEnElBotonAgregar()
        {
            try
            {
                ProductModel productModel = new ProductModel();
                productModel.Name = _product.Name;
                productModel.Description = _product.Description;
                productModel.Code = _product.Code;
                productModel.Prize = _product.Price;
                _productController.PostProduct(productModel);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"el producto se agrega a la lista de productos")]
        public void ThenElProductoSeAgregaALaListaDeProductos()
        {
            if (_exception == null)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Then(@"salta un mensaje de error con codigo invalido y el producto no se agrega a la lista")]
        public void ThenSaltaUnMensajeDeErrorConCodigoInvalidoYElProductoNoSeAgregaALaLista()
        {
            if (_exception != null)
            {
                Assert.Equals(_exception.Message, "El código del producto debe ser númerico de 5 dígitos");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Then(@"salta un mensaje de error con nombre invalido y el producto no se agrega a la lista")]
        public void ThenSaltaUnMensajeDeErrorConNombreInvalidoYElProductoNoSeAgregaALaLista()
        {
            if (_exception != null)
            {
                Assert.Equals(_exception.Message, "El nombre del procuto debe ser de 30 caracteres");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Then(@"salta un mensaje de error con descripcion invalida y el producto no se agrega a la lista")]
        public void ThenSaltaUnMensajeDeErrorConDescripcionInvalidaYElProductoNoSeAgregaALaLista()
        {
            if (_exception != null)
            {
                Assert.Equals(_exception.Message, "La descripción de un producto no puede ser vacía ni con más de 70 caracteres");
            }
            else
            {
                Assert.Fail();
            }
        }



    }
}
