using Atm.Models;
using Atm.ViewModels;
using System.Threading.Tasks;

namespace Atm.Services.Services.Interfaces
{
    public interface IMoneyService
    {
        /// <summary>
        /// Change money to smaller notes
        /// </summary>
        /// <param name="amount">amount of money to change</param>
        /// <returns></returns>
        WithdrawalViewModel ChangeMoney(decimal? amount);
    }
}
