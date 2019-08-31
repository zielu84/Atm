using System;
using System.Collections.Generic;

namespace Atm.Models
{
    public class WithdrawRequest
    {
        public string accountNumber;
        public decimal? amount;

        public WithdrawRequest(string accountNumber, decimal? amount)
        {
            this.accountNumber = accountNumber;
            this.amount = amount;
        }
    }
}
