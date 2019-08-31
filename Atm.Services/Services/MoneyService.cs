using Atm.Models;
using Atm.Models.Exceptions;
using Atm.Services.Services.Interfaces;
using Atm.ViewModels;
using System;
using System.Threading.Tasks;

namespace Atm.Services.Services
{
    public class MoneyService : IMoneyService
    {
        private readonly decimal[] notes = new decimal[4] { 100, 50, 20, 10 };

        public WithdrawalViewModel ChangeMoney(decimal? amount)
        {
            var withdrawal = new WithdrawalViewModel();

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
                    withdrawal.Notes.Add(new NoteChange(note, (int)(remainAmount / note)));
                    remainAmount %= note;
                }
            }

            return withdrawal;
        }
    }
}
