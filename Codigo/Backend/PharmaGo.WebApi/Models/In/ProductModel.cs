using PharmaGo.Domain.Entities;
using PharmaGo.Exceptions;

namespace PharmaGo.WebApi.Models.In
{
    public class ProductModel
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal Prize { get; set; }

        public Product ToEntity()
        {
            return new Product()
            {
                Code = this.Code,
                Name = this.Name,
                Description = this.Description,
                Price = this.Prize
            };
        }
    }
}
