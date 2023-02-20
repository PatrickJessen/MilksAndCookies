using Microsoft.AspNetCore.Mvc;

namespace MilksAndCookies.Controllers
{
    [Produces("application/json")]
    [Route("api/SetCookie")]
    public class SetCookieController : Controller
    {
        // GET: api/SetCookie
        [HttpGet]
        public string Get(string favoriteMilkshake)
        {
            //do stuff her
            return favoriteMilkshake;
        }
        // GET: api/SetCookie
        [HttpGet]
        [Route("[action]")]
        public List<Product> GetFromCookie()
        {
            return SessionExtensions.GetObjectFromJson<List<Product>>(HttpContext.Session, "test"); //Something here;
 }
    }
}
