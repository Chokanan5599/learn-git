using Microsoft.AspNetCore.Mvc;

namespace TLA_SalseForeCast.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Quotation_Draft()
        {
            return View();
        }
    }
}
