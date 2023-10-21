using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaGo.Domain.Entities
{
    public class Product
    {
        public string Name;

        public int Code { get; set; }
        public string Description { get; set; }
        public float Prize { get; set; }
    }
}
