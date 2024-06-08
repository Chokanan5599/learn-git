using Microsoft.AspNetCore.Mvc;

namespace TLA_SalseForeCast.Controllers
{
    [ApiController]
    [Route("Login")]
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
