using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MilkAndCookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkshakeController : ControllerBase
    {
        [HttpGet("{favoriteMilkshake}")]
        public ActionResult<string> Get(string favoriteMilkshake)
        {
            CookieOptions co = new CookieOptions();
            co.MaxAge = TimeSpan.FromSeconds(60 * 5);
            Response.Cookies.Append("favoriteMilkshake", favoriteMilkshake);
            return StatusCode(200,favoriteMilkshake);
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            if (Request.Cookies["favoriteMilkshake"].Equals(null))
            {
                return StatusCode(404, "Unknown");
            }

            string favoriteMilkshake = Request.Cookies["favoriteMilkshake"]!;
            return StatusCode(200, favoriteMilkshake);
        }
    }
}
