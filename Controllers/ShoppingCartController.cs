using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        [HttpGet]
        public ActionResult<List<Product>> Get(string name, string price)
        {
            Product product = new Product(name, price);

            List<Product> products = HttpContext.Session.GetObjectFromJson<List<Product>>("Test") ?? new List<Product>();

            products.Add(product);

            HttpContext.Session.SetObjectAsJson("Test", products);

            return StatusCode(201, HttpContext.Session.GetObjectFromJson<List<Product>>("Test"));
        }
    }
}
