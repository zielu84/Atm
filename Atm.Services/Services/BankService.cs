using Atm.Models;
using Atm.Models.Exceptions;
using Atm.Models.Models;
using Atm.Services.Services.Interfaces;
using Atm.ViewModels;
using Atmi.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Atm.Services.Services
{
    public class BankService : IBankService
    {
        private readonly IBaseRepository Repository;

        public BankService(IBaseRepository repository)
        {
            Repository = repository;
        }

        public async Task<bool> CheckAccountNumber(string accountNumber)
        {
            var account = (await Repository.Get<Account>(x => x.AccountNumber == accountNumber)).FirstOrDefault();
            if (account != null)
            {
                return true;
            }
            else
            {
                throw new InvalidArgumentException("Wrong account number", "accountNumber");
            }
        }

        public async Task WithdrawMoney(string accountNumber, decimal amount)
        {
            if (amount > 0)
            {
                var account = (await Repository.Get<Account>(x => x.AccountNumber == accountNumber)).FirstOrDefault();

                await Repository.Add<Withdrawal>(new Withdrawal
                {
                    AccountId = account.Id,
                    Amount = amount,
                });

                await Repository.SaveChanges();
            }
        }
    }
}
