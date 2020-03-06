using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TheDebtBook.DTO;

namespace TheDebtBook.Data
{
    class FileController
    {
        private string textFile = "DebtorsAndCreditors.txt";

        public void WriteToFile(List<DebtorOrCreditor> debtorsAndCreditors)
        {
            using (FileStream stream = new FileStream(textFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                foreach (DebtorOrCreditor dto in debtorsAndCreditors)
                    formatter.Serialize(stream, dto);

            }
        }

        public List<DebtorOrCreditor> ReadFromFile()
        {
            List<DebtorOrCreditor> debtorsAndCreditors = new List<DebtorOrCreditor>();
            
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
