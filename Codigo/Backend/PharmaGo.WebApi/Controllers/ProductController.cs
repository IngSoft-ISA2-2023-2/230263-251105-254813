using Microsoft.AspNetCore.Mvc;
using PharmaGo.BusinessLogic;

namespace PharmaGo.WebApi.Controllers
{
    public class ProductController : Controller
    { 

        public IActionResult Index()
        {
            return View();
        }

        public void PostProduct()
        {
            throw new NotImplementedException();
        }
    }
}
