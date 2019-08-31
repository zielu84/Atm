using Atm.Models.Exceptions;
using Atm.Services.Services;
using Atm.Services.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Atm.Tests.Services
{
    public class MoneyTest
    {
        readonly IMoneyService MoneyService = new MoneyService();

        [Fact]
        public void Change_AmountShouldHaveNoFiversAsync()
        {
            decimal amount = 155;

            Assert.Throws<NoteUnavailableException>("amount", () => MoneyService.ChangeMoney(amount));
        }

        [Fact]
        public void Change_AmountShouldNotBeNegative()
        {
            decimal amount = -155;

            Assert.Throws<InvalidArgumentException>("amount", () => MoneyService.ChangeMoney(amount));
        }

        [Fact]
        public void Change_AmountCanBeNull()
        {
            var withdrawal = MoneyService.ChangeMoney(null);

            Assert.Empty(withdrawal.Notes);
        }

        [Theory]
        [InlineData(10, 10, 1)]
        [InlineData(120, 100, 1)]
        [InlineData(120, 20, 1)]
        [InlineData(140, 20, 2)]
        public void Change_NotesNumberShouldBeCorrect(decimal amount, decimal value, int notesAmount)
        {
            var withdrawal = MoneyService.ChangeMoney(amount);

            Assert.Equal(notesAmount, withdrawal.Notes.Any(x => x.note == value) ? 
                withdrawal.Notes.Where(x => x.note == value).FirstOrDefault().amount : 0);
        }
    }
}
