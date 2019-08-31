using Atm.Models;
using Atm.ViewModels;
using System.Threading.Tasks;

namespace Atm.Services.Services.Interfaces
{
    public interface IBankService
    {
        /// <summary>
        /// Withdraw money from bank account
        /// </summary>
        /// <param name="accountNumber">bank account number</param>
        /// <param name="amount">amount of money to withdraw</param>
        /// <returns></returns>
        bool WithdrawMoney(string accountNumber, decimal? amount);
    }
}
