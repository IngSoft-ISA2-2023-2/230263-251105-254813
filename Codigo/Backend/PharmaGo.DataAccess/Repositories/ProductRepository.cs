using PharmaGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace PharmaGo.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        private readonly PharmacyGoDbContext _context;

        public ProductRepository(PharmacyGoDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
