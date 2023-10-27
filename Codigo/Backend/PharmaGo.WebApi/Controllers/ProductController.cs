using Microsoft.AspNetCore.Mvc;
using PharmaGo.BusinessLogic;
using PharmaGo.Domain.Entities;
using PharmaGo.IBusinessLogic;
using PharmaGo.WebApi.Enums;
using PharmaGo.WebApi.Filters;
using PharmaGo.WebApi.Models.In;
using PharmaGo.WebApi.Models.Out;

namespace PharmaGo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager manager)
        {
            _productManager = manager;
        }

        [HttpPost]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult PostProduct([FromBody] ProductModel productModel)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            Product productCreated = _productManager.CreateProduct(productModel.ToEntity(),token);
            ProductModelResponse productResponse = new ProductModelResponse(productCreated);
            return Ok(productResponse);
        }

        [HttpDelete("{id}")]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            try
            {
                _productManager.DeleteProduct(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult Update([FromRoute] int id, [FromBody] ProductModel productModel)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            Product product = _productManager.Update(id, productModel.ToEntity());
            return Ok(new ProductModelResponse(product));
        }
    }
}
