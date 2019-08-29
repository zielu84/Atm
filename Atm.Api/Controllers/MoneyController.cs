using Atm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Atm.Api.Controllers
{
    /// <summary>
    /// Money Controller
    /// </summary>
    public class MoneyController : BaseController
    {
        /// <summary>
        /// Returns withdrawal
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        /// <returns></returns>
        [HttpGet]
        [Route("withdraw")]
        public ActionResult<Withdrawal> Withdraw()
        {
            return new Withdrawal();
        }
    }
}