using System;

namespace TheDebtBook.DTO
{
    [System.Serializable]
    public class Debit
   {
      public DateTime DebitDateTime { get; set; }
      public double DebitValue { get; set; }

        public Debit(DateTime debitDateTime, double debitValue)
        {
            DebitDateTime = debitDateTime;
            DebitValue = debitValue;
        }
   }
}
