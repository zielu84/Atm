using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atm.Models.Models
{
    public class Withdrawal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
