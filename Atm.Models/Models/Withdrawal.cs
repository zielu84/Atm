using System;
using System.Collections.Generic;

namespace Atm.Models
{
    public class Withdrawal
    {
        public List<Tuple<decimal, int>> Notes;

        public Withdrawal ()
        {
            Notes = new List<Tuple<decimal, int>>();
        }
    }
}
