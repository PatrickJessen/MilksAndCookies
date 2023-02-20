using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MilksAndCookies.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCartController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("product")]
        public IEnumerable<Product> Get(string name, decimal price)
        {
            // Get product list from session
            List<Product> products = SessionExtensions.GetObjectFromJson<List<Product>>(HttpContext.Session, "test");
            if (products == null)
            {
                // Create new list if session list is not instatiated
                products = new List<Product>();
            }
            products.Add(new Product(name, price));
            // Set session list
            SessionExtensions.SetObjectAsJson(HttpContext.Session, "test", products);
            return products;
        }

        [HttpGet("DeleteProduct")]
        public IActionResult Delete(string name)
        {
            // Get product list from session
            List<Product> products = SessionExtensions.GetObjectFromJson<List<Product>>(HttpContext.Session, "test");
            if (products != null)
            {
                // Deletes item from list by name
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Name == name)
                    {
                        string returnMsg = "Successfully deleted " + products[i].Name;
                        products.RemoveAt(i);
                        SessionExtensions.SetObjectAsJson(HttpContext.Session, "test", products);
                        return Ok(returnMsg);
                    }
                }
            }
            return Problem("Could not find item");
        }
    }
}
