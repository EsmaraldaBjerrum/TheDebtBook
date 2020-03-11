using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDebtBook.DTO;

namespace TheDebtBook.ViewModels
{
    public class AddViewModel : BindableBase
    {
        public AddViewModel(string title, DebtorOrCreditor debtorOrCreditor)
        {
            NewDebtorOrCreditor = debtorOrCreditor;

        }

        DebtorOrCreditor newDebtorOrCreditor;
        public DebtorOrCreditor NewDebtorOrCreditor
        {
            get { return newDebtorOrCreditor; }
            set
            {
                SetProperty(ref newDebtorOrCreditor, value);
            }
        }

        string title;
        public string Title
        { 
            get { return title; }
            set
            {
                SetProperty(ref title, value);
            }
        }

        public bool IsNameAndDebitValid
        {
            get
            {
                bool isNameAndDebitValid = true;
                if (string.IsNullOrWhiteSpace(NewDebtorOrCreditor.Name) || double.IsNaN(NewDebtorOrCreditor.Sum))
                    isNameAndDebitValid = false;
                return isNameAndDebitValid;
            }
        }
    }
}
