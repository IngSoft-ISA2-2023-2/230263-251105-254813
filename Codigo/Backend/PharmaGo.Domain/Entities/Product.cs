using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaGo.Exceptions;

namespace PharmaGo.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Pharmacy? Pharmacy { get; set; }
    }
}
