using System.Collections.Generic;
using System.Text;

namespace TheDebtBook.DTO
{
    [System.Serializable]
    public class DebtorOrCreditor
   {
        public string Name { get; set; }
        public double Sum { get; set; }
        public List<Debit> DebitsList { get; set; }

        public DebtorOrCreditor(string name, double sum)
        {
            Name = name;
            Sum = sum;
            DebitsList = new List<Debit>();
        }




   }
}
