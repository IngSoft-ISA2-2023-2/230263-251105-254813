using PharmaGo.DataAccess.Repositories;
using PharmaGo.Domain.Entities;
using PharmaGo.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaGo.BusinessLogic
{
    public class ProductManager
    {
        private readonly IRepository<Session> _sessionRepository;
        private readonly IRepository<User> _userRepository;

        public List<Product> Products { get; set; }

        public void AddProduct()
        {
            throw new NotImplementedException();
        }

        public void CreateProduct(string empleado, Product product)
        {
            string token = empleado;
            var guidToken = new Guid(token);
            Session session = _sessionRepository.GetOneByExpression(s => s.Token == guidToken);
            var userId = session.UserId;
            User user = _userRepository.GetOneDetailByExpression(u => u.Id == userId);


        }
    }
}
