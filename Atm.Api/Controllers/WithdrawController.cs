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
        public async Task<WithdrawalViewModel> Withdraw([FromBody] WithdrawRequest model)
        {
            await BankService.CheckAccountNumber(model.accountNumber);
            var changeModel = MoneyService.ChangeMoney(model.amount);
            await BankService.WithdrawMoney(model.accountNumber, model.amount ?? 0);
            
            return changeModel;
        }
    }
}