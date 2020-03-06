using System.Collections.Generic;

namespace TheDebtBook.DTO
{
   public class DebtorOrCreditor
   {
      public string Name { get; set; }
      public double Sum { get; set; }
      public List<Debit> DebitsList { get; set; }
   }
}
