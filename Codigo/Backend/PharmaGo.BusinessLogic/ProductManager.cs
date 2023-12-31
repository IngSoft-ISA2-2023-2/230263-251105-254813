﻿using PharmaGo.DataAccess.Repositories;
using PharmaGo.Domain.Entities;
using PharmaGo.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaGo.IBusinessLogic;
using PharmaGo.Exceptions;
using Microsoft.EntityFrameworkCore;
using PharmaGo.Domain.SearchCriterias;

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
                           IRepository<Pharmacy> pharmacyRepository, IRepository<Product> productRepository)
        {
            _sessionRepository = sessionRespository;
            _userRepository = userRespository;
            _pharmacyRepository = pharmacyRepository;
            _productRepository = productRepository;
        }

        public Product CreateProduct(Product product, string empleado)
        {
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
            var existingPharmacy = _pharmacyRepository.GetOneByExpression(p => p.Id == pharmacyOfProduct.Id);
            if (existingPharmacy == null)
            {
                // La entidad Pharmacy no está en el contexto, puedes agregarla a product
                product.Pharmacy = pharmacyOfProduct;
            }
            else
            {
                // La entidad Pharmacy ya está en el contexto, no es necesario agregarla nuevamente
                product.Pharmacy = existingPharmacy;
            }
            product.Pharmacy.Id = pharmacyOfProduct.Id;
            _productRepository.InsertOne(product);
            _productRepository.Save();
            return product;
        }

        void IProductManager.DeleteProduct(int code)
        {
            Product productSaved = _productRepository.GetOneByExpression(p => p.Code == code);
            if (productSaved == null)
            {
                throw new ResourceNotFoundException("The product to delete does not exist");
            }
            if (productSaved.Deleted)
            {
                throw new ResourceNotFoundException("The product you want to delete has already been deleted");
            }
            productSaved.Deleted = true;
            _productRepository.UpdateOne(productSaved);
            _productRepository.Save();
        }

        public Product Update(int id, Product productUpdate)
        {
            if (productUpdate == null)
            {
                throw new ResourceNotFoundException("The updated product is invalid.");
            }
            productUpdate.ValidProduct();
            var productSaved = _productRepository.GetOneByExpression(d => d.Id == id);
            if (productSaved == null)
            {
                throw new ResourceNotFoundException("The product to update does not exist.");
            }
            productSaved.Code = productUpdate.Code;
            productSaved.Name = productUpdate.Name;
            productSaved.Description = productUpdate.Description;
            productSaved.Price = productUpdate.Price;
            _productRepository.UpdateOne(productSaved);
            _productRepository.Save();
            return productSaved;
        }

        public IEnumerable<Product> GetAllProducts(string token)
        {
            var guidToken = new Guid(token);
            Session session = _sessionRepository.GetOneByExpression(s => s.Token == guidToken);
            var userId = session.UserId;
            User user = _userRepository.GetOneDetailByExpression(u => u.Id == userId);
            Pharmacy pharmacyOfUser = _pharmacyRepository.GetOneByExpression(p => p.Name == user.Pharmacy.Name);
            if (pharmacyOfUser == null)
            {
                throw new ResourceNotFoundException("The pharmacy to get products of does not exist.");
            }
            return _productRepository.GetAllProducts(pharmacyOfUser);
        }
    }
}
