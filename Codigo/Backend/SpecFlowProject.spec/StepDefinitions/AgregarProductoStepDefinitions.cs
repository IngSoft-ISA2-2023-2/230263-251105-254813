using NUnit.Framework;
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

        
        private readonly Product _product = new Product();
        private readonly ProductModelResponse _result;
        private ProductController _productController;
        private int _resultScenarioOne = 1;
        private Exception _exception;

        public AgregarProductoStepDefinitions(ProductController controller)
        {
            //_productManager = manager;
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


        [Then(@"muestra el mensaje is Agregado")]
        public void ThenMuestraElMensajeIsAgregado()
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
    }
}
