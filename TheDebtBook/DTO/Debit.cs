using System;

namespace TheDebtBook.DTO
{
    [System.Serializable]
    public class Debit
   {

        private DateTime _date;
        public string Date { 
            get
            {
                return _date.ToShortDateString();
            }                
             set
             {
                _date = DateTime.Parse(value);
             }                
       }

        public double Value { get; set; }

        public Debit(DateTime debitDateTime, double debitValue)
        {
            _date = debitDateTime;
            Value = debitValue;
        }
   }
}
