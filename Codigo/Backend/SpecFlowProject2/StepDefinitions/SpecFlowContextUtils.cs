using Moq;
using PharmaGo.Domain.Entities;
using PharmaGo.IBusinessLogic;
using PharmaGo.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.spec.StepDefinitions
{
    public static class SpecFlowContextUtils
    {
        private const string ProductManagerKey = "ProductManager";
        private const string ProductRepositoryKey = "RepositoryKey";
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
        public static IRepository<Product> GetRepository()
        {
            if (!ScenarioContext.Current.ContainsKey(ProductRepositoryKey))
            {
   
                // Ejemplo de configuración de un Mock:
                var repositoryMock = new Mock<IRepository<Product>>();
                repositoryMock.Setup(repo => repo.GetOneByExpression(It.Is<Expression<Func<Product, bool>>>(expression => true)))
                             .Returns(new Product { Id = 1, Name = "Shampoo" });

                ScenarioContext.Current.Add(ProductRepositoryKey, repositoryMock.Object);
            }

            return (IRepository<Product>)ScenarioContext.Current[ProductRepositoryKey];
        
        }
    }
}
