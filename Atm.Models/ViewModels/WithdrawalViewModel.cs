using System;
using System.Collections.Generic;

namespace Atm.ViewModels
{
    public class WithdrawalViewModel
    {
        public List<NoteChange> Notes;

        public WithdrawalViewModel()
        {
            Notes = new List<NoteChange>();
        }
    }

    public class NoteChange
    {
        public readonly decimal note;
        public readonly int amount;

        public NoteChange(decimal note, int amount)
        {
            this.note = note;
            this.amount = amount;
        }
    }
}
