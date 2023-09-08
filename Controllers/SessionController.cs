using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MilkAndCookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : Controller
    {
        [HttpDelete]
        public ActionResult<List<Product>> Delete(string name, string price)
        {
            //Product product = new Product(name, price);

            List<Product> products = HttpContext.Session.GetObjectFromJson<List<Product>>("Test") ?? new List<Product>();

            Product product = products.FirstOrDefault(x => x.Name == name);

            products.Remove(product);

            HttpContext.Session.SetObjectAsJson("Test", products);

            return StatusCode(201, HttpContext.Session.GetObjectFromJson<List<Product>>("Test"));
        }
    }
}
