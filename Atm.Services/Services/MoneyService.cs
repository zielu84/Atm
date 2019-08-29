using Atm.Models;
using Atm.Models.Exceptions;
using Atm.Services.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Atm.Services.Services
{
    public class MoneyService : IMoneyService
    {
        private readonly decimal[] notes = new decimal[4] { 100, 50, 20, 10 };

        public async Task<Withdrawal> GetWithdrawal(decimal? amount)
        {
            var withdrawal = new Withdrawal();

            if (amount < 0)
            {
                throw new InvalidArgumentException("Invalid amount", "amount");
            }
            if (amount % 10 > 0)
            {
                throw new NoteUnavailableException("Invalid amount", "amount");
            }

            decimal? remainAmount = amount;
            foreach (var note in notes)
            {
                if (remainAmount % note < remainAmount)
                {
                    withdrawal.Notes.Add(new Tuple<decimal, int>(note, (int)(remainAmount / note)));
                    remainAmount %= note;
                }
            }

            return withdrawal;
        }
    }
}
