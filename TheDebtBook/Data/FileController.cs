using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TheDebtBook.DTO;

namespace TheDebtBook.Data
{
   class FileController
   {
      private string textFile = "DebtorsAndCreditors.txt";

      public void WriteToFile(ObservableCollection<DebtorOrCreditor> debtorsAndCreditors)
      {
         using (FileStream stream = new FileStream(textFile, FileMode.OpenOrCreate, FileAccess.Write))
         {
            BinaryFormatter formatter = new BinaryFormatter();
            foreach (DebtorOrCreditor dto in debtorsAndCreditors)
               formatter.Serialize(stream, dto);
         }
      }

      public ObservableCollection<DebtorOrCreditor> ReadFromFile()
      {
         ObservableCollection<DebtorOrCreditor> debtorsAndCreditors = new ObservableCollection<DebtorOrCreditor>();

         // Read the file and display it line by line.
         using (FileStream stream = new FileStream(textFile, FileMode.OpenOrCreate, FileAccess.Read))
         {
            while (stream.Position < stream.Length)
            {
               BinaryFormatter formatter = new BinaryFormatter();

               debtorsAndCreditors.Add((DebtorOrCreditor)formatter.Deserialize(stream));
            }
         }

         return debtorsAndCreditors;
      }


   }
}
