using Atm.Models;
using Atm.Services.Services.Interfaces;
using Atm.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atm.Api.Controllers
{
    /// <summary>
    /// Money Controller
    /// </summary>
    public class WithdrawController : BaseController
    {
        public WithdrawController(IMoneyService moneyService, IBankService bankService) 
            : base(moneyService, bankService)
        { }

        /// <summary>
        /// Returns withdrawal
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        /// <returns></returns>
        [HttpPost]
        [Route("withdraw")]
        public WithdrawalViewModel Withdraw([FromBody] WithdrawRequest model)
        {
            var changeModel = MoneyService.ChangeMoney(model.amount);
            var withdrawModel = BankService.WithdrawMoney(model.accountNumber, model.amount);
            return changeModel;
        }
    }
}