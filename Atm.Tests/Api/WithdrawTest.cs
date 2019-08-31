using Atm.Api.Controllers;
using Atm.Models;
using Atm.Services.Services;
using Atm.Services.Services.Interfaces;
using System.Linq;
using Xunit;

namespace Atm.Tests.Services
{
    public class WithdrawTest
    {
        readonly IBankService BankService = new BankService();
        readonly IMoneyService MoneyService = new MoneyService();

        [Theory]
        [InlineData(10, 10, 1)]
        [InlineData(120, 100, 1)]
        [InlineData(120, 20, 1)]
        [InlineData(140, 20, 2)]
        public void Withdraw_NotesNumberShouldBeCorrect(decimal amount, decimal value, int notesAmount)
        {
            var controller = new WithdrawController(MoneyService, BankService);
            var request = new WithdrawRequest("1234-1234-1234", amount);

            var result = controller.Withdraw(request);

            Assert.Equal(notesAmount, result.Notes.Any(x => x.note == value) ? 
                result.Notes.Where(x => x.note == value).FirstOrDefault().amount : 0);
        }
    }
}
