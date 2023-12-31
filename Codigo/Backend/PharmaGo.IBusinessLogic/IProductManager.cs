﻿using PharmaGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaGo.IBusinessLogic
{
    public interface IProductManager
    {
        Product CreateProduct(Product product, string token);
        void DeleteProduct(int id);
        IEnumerable<Product> GetAllProducts(string token);
        Product Update(int id, Product product);
    }
}
