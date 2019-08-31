using Atm.Models;
using Atm.Models.Exceptions;
using Atm.Services.Services.Interfaces;
using Atm.ViewModels;
using System;
using System.Threading.Tasks;

namespace Atm.Services.Services
{
    public class BankService : IBankService
    {
        public bool WithdrawMoney(string accountNumber, decimal? amount)
        {
            // TODO

            return true;
        }
    }
}
