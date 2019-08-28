using Microsoft.AspNetCore.Mvc;

namespace Atm.Api.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult GetAccount(string accountNumber)
        {
            return View();
        }
    }
}