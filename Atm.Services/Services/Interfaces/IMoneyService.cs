using Atm.Models;
using System.Threading.Tasks;

namespace Atm.Services.Services.Interfaces
{
    public interface IMoneyService
    {
        /// <summary>
        /// Get withdrawal object
        /// </summary>
        /// <param name="amount">amount of money to withdraw</param>
        /// <returns></returns>
        Task<Withdrawal> GetWithdrawal(decimal? amount);
    }
}
