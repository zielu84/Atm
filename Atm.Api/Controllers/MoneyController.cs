using Microsoft.AspNetCore.Mvc;

namespace Atm.Api.Controllers
{
    public class MoneyController : Controller
    {
        public IActionResult Withdraw(decimal amount)
        {
            return View();
        }
    }
}