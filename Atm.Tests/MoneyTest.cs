using Atm.Models.Exceptions;
using Atm.Services.Services;
using Atm.Services.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Atm.Services.Test
{
    public class MoneyTest
    {
        readonly IMoneyService MoneyService = new MoneyService();

        [Fact]
        public async Task GetWithdrawal_AmountShouldHaveNoFiversAsync()
        {
            decimal amount = 155;

            await Assert.ThrowsAsync<NoteUnavailableException>("amount", () => MoneyService.GetWithdrawal(amount));
        }

        [Fact]
        public async Task GetWithdrawal_AmountShouldNotBeNegative()
        {
            decimal amount = -155;

            await Assert.ThrowsAsync<InvalidArgumentException>("amount", () => MoneyService.GetWithdrawal(amount));
        }

        [Fact]
        public async void GetWithdrawal_AmountCanBeNull()
        {
            var withdrawal = await MoneyService.GetWithdrawal(null);

            Assert.Empty(withdrawal.Notes);
        }

        [Theory]
        [InlineData(10, 10, 1)]
        [InlineData(120, 100, 1)]
        [InlineData(120, 20, 1)]
        [InlineData(140, 20, 2)]
        public async void GetWithdrawal_NotesNumberShouldBeCorrect(decimal amount, decimal value, int notesAmount)
        {
            var withdrawal = await MoneyService.GetWithdrawal(amount);

            Assert.Equal(notesAmount, withdrawal.Notes.Any(x => x.Item1 == value) ? 
                withdrawal.Notes.Where(x => x.Item1 == value).FirstOrDefault().Item2 : 0);
        }
    }
}
