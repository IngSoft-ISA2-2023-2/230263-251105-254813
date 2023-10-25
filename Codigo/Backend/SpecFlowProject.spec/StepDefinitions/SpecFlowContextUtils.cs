using Moq;
using PharmaGo.DataAccess.Repositories;
using PharmaGo.DataAccess;
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

        public static IProductManager GetProductManager()
        {
            if (!ScenarioContext.Current.ContainsKey(ProductManagerKey))
            {
                var productManagerMock = new Mock<IProductManager>();
                productManagerMock.Setup(manager => manager.CreateProduct(It.IsAny<Product>(), It.IsAny<string>()))
                                 .Returns(new Product());
                ScenarioContext.Current.Add(ProductManagerKey, productManagerMock.Object);
            }
            return (IProductManager)ScenarioContext.Current[ProductManagerKey];
        }

        public static IRepository<T> GetMockedRepository<T>() where T : class
        {
            var repositoryMock = new Mock<IRepository<T>>();

            repositoryMock.Setup(repo => repo.GetAllByExpression(It.IsAny<Expression<Func<T, bool>>>()))
                .Returns((Expression<Func<T, bool>> expression) => new List<T>().Where(expression.Compile()));

            repositoryMock.Setup(repo => repo.GetOneByExpression(It.IsAny<Expression<Func<T, bool>>>()))
                .Returns((Expression<Func<T, bool>> expression) => new List<T>().FirstOrDefault(expression.Compile()));

            repositoryMock.Setup(repo => repo.InsertOne(It.IsAny<T>()));
            repositoryMock.Setup(repo => repo.DeleteOne(It.IsAny<T>()));
            repositoryMock.Setup(repo => repo.UpdateOne(It.IsAny<T>()));
            repositoryMock.Setup(repo => repo.Save());
            repositoryMock.Setup(repo => repo.Exists(It.IsAny<Expression<Func<T, bool>>>()))
    .Returns((Expression<Func<T, bool>> expression) => new List<T>().Any(expression.Compile()));

            repositoryMock.Setup(repo => repo.Exists(It.IsAny<T>()))
                .Returns((T elem) => new List<T>().Contains(elem));


            return repositoryMock.Object;
        }


        public static SessionRepository GetMockedSessionRepository()
        {
            var dbContextMock = new Mock<PharmacyGoDbContext>();
            dbContextMock.Setup(context => context.Set<Session>().Any(e => e.Id == It.IsAny<int>())).Returns(true);
            dbContextMock.Setup(context => context.Set<Session>().Find(It.IsAny<int>()))
                .Returns((int id) => new List<Session>().FirstOrDefault(e => e.Id == id));
            var sessionRepository = new SessionRepository(dbContextMock.Object);
            return sessionRepository;
        }
    }
}
