using Atm.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atm.Api.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
        protected IMoneyService MoneyService;
        protected IBankService BankService;

        public BaseController(IMoneyService moneyService, IBankService bankService)
        {
            MoneyService = moneyService;
            BankService = bankService;
        }
    }
}