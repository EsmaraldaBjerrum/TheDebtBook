using System.Collections.Generic;
using System.Text;

namespace TheDebtBook.DTO
{
    [System.Serializable]
    public class DebtorOrCreditor
   {
        public string Name { get; set; }
        public double Sum {
            get
            {
                double sum = 0;
                foreach (Debit debit in DebitsList)
                {
                    sum += debit.Value;
                }
                return sum;
            }
            set
            {
                
            }
        }
        public List<Debit> DebitsList { get; set; }

        public DebtorOrCreditor(string name)
        {
            Name = name;
            DebitsList = new List<Debit>();
        }

        public DebtorOrCreditor()
        {
            DebitsList = new List<Debit>();
        }

        public DebtorOrCreditor Clone()
        {
           return this.MemberwiseClone() as DebtorOrCreditor;
        }
   }
}
