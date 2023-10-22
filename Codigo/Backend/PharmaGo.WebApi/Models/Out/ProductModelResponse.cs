using PharmaGo.Domain.Entities;

namespace PharmaGo.WebApi.Models.Out
{
    public class ProductModelResponse
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ProductModelResponse(Product product)
        {
            Code = product.Code;
            Name = product.Name;
            Description = product.Description;
        }
    }
}
