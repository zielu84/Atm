using Microsoft.AspNetCore.Mvc;

namespace Atm.Api.Controllers
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// Account Controller
        /// </summary>
        /// <param name="accountNumber">Bank account number</param>
        /// <returns></returns>
        public IActionResult GetAccount(string accountNumber)
        {
            return View();
        }
    }
}