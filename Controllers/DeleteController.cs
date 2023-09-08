using Microsoft.AspNetCore.Mvc;

namespace MilkAndCookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpDelete]
        public ActionResult<string> Delete()
        {
            if (Request.Cookies["favoriteMilkshake"].Equals(null))
            {
                return StatusCode(404, "Unknown");
            }

            Response.Cookies.Delete("favoriteMilkshake");

            return StatusCode(StatusCodes.Status200OK, "Deleted succesfully");
        }
    }
}
