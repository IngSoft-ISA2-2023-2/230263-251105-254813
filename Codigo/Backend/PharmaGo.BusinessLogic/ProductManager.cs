using PharmaGo.DataAccess.Repositories;
using PharmaGo.Domain.Entities;
using PharmaGo.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaGo.IBusinessLogic;
using PharmaGo.Exceptions;

namespace PharmaGo.BusinessLogic
{
    public class ProductManager : IProductManager
    {
        private readonly IRepository<Session> _sessionRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Pharmacy> _pharmacyRepository;
        private readonly IRepository<Product> _productRepository;

        public List<Product> Products { get; set; }

        public ProductManager(IRepository<Session> sessionRespository,
                           IRepository<User> userRespository,
                           IRepository<Pharmacy> pharmacyRepository)
        {
            _sessionRepository = sessionRespository;
            _userRepository = userRespository;
            _pharmacyRepository = pharmacyRepository;
        }

        public Product CreateProduct(Product product, string empleado)
        {
            //Controlar product not null
            if (product == null)
            {
                throw new ResourceNotFoundException("Please create a product before inserting it.");
            }
            product.ValidProduct();

            string token = empleado;
            var guidToken = new Guid(token);
            Session session = _sessionRepository.GetOneByExpression(s => s.Token == guidToken);
            var userId = session.UserId;
            User user = _userRepository.GetOneDetailByExpression(u => u.Id == userId);

            Pharmacy pharmacyOfProduct = _pharmacyRepository.GetOneByExpression(p => p.Name == user.Pharmacy.Name);
            if (pharmacyOfProduct == null)
            {
                throw new ResourceNotFoundException("The pharmacy of the drug does not exist.");
            }

            if (_productRepository.Exists(d => d.Code == product.Code && d.Pharmacy.Name == pharmacyOfProduct.Name))
            {
                throw new InvalidResourceException("The code product already exists in that pharmacy.");
            }

            if (product.Pharmacy == null)
            {
                product.Pharmacy = new Pharmacy();
            }
            product.Pharmacy.Id = pharmacyOfProduct.Id;
            _productRepository.InsertOne(product);
            _productRepository.Save();
            return product;

        }
    }
}
