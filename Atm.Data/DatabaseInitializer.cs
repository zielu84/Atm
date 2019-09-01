using Atm.Models.Models;
using System.Linq;

namespace Atm.Data
{
    public class DatabaseInitializer
    {
        public static void Seed(AtmDbContext context)
        {
            if (!context.Account.Any(x => x.AccountNumber == "10-1234-1234-1234-1234"))
                context.Account.Add(new Account {AccountNumber = "10-1234-1234-1234-1234", FirstName = "John", LastName = "Doe" });

            context.SaveChangesAsync().Wait();
        }
    }
}
