using Atm.Models;
using Atm.ViewModels;
using System.Threading.Tasks;

namespace Atm.Services.Services.Interfaces
{
    public interface IBankService
    {
        /// <summary>
        /// Checks account number validity
        /// </summary>
        /// <param name="accountNumber">bank account number</param>
        /// <returns></returns>
        Task<bool> CheckAccountNumber(string accountNumber);

        /// <summary>
        /// Withdraw money from bank account
        /// </summary>
        /// <param name="accountNumber">bank account number</param>
        /// <param name="amount">amount of money to withdraw</param>
        /// <returns></returns>
        Task WithdrawMoney(string accountNumber, decimal amount);
    }
}
