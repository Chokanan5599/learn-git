using Microsoft.AspNetCore.Mvc;

namespace TLA_SalseForeCast.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult GetSession(string first_name, string last_name, string userName) {

            try {
                HttpContext.Session.SetString("first_name", first_name);
                //first_name = HttpContext.Session.GetString("first_name");
                //ViewData["first_name"] = first_name;

                HttpContext.Session.SetString("last_name", last_name);
                //last_name = HttpContext.Session.GetString("last_name");
                //ViewData["last_name"] = last_name;

                HttpContext.Session.SetString("UserName", userName);
                //userName = HttpContext.Session.GetString("UserName");
                //ViewData["UserName"] = userName;

               
            }
            catch (Exception ex) {
                //throw ex;
                return Ok("NG");
            }
            return Ok("Successful!"); 
        }
    }
}
