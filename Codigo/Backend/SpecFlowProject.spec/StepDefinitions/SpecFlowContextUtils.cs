using Moq;
using PharmaGo.Domain.Entities;
using PharmaGo.IBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.spec.StepDefinitions
{
    public static class SpecFlowContextUtils
    {
        private const string ProductManagerKey = "ProductManager";

        public static IProductManager GetProductManager()
        {
            if (!ScenarioContext.Current.ContainsKey(ProductManagerKey))
            {
                // Configura el comportamiento de tu Mock de IProductManager aquí
                var productManagerMock = new Mock<IProductManager>();
                // Ejemplo de comportamiento de retorno
                productManagerMock.Setup(manager => manager.CreateProduct(It.IsAny<Product>(), It.IsAny<string>()))
                                 .Returns(new Product());

                ScenarioContext.Current.Add(ProductManagerKey, productManagerMock.Object);
            }

            return (IProductManager)ScenarioContext.Current[ProductManagerKey];
        }
    }
}
