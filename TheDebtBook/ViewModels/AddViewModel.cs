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
            Title = title;
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

        string newDebit;
        public string NewDebit
        {
            get { return newDebit; }
            set
            {
                SetProperty(ref newDebit, value);
                newDebit = newDebit.Replace('.', ',');
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

        public bool IsNameValid
        {
            get
            {
                bool isNameValid = true;
                if (string.IsNullOrWhiteSpace(NewDebtorOrCreditor.Name))
                    isNameValid = false;
                return isNameValid;
            }
        }
        public bool IsDebitValid
        {
            get
            {
                bool isDebitValid = true;
                double debit = 0;
                if (double.TryParse(NewDebit, out debit))
                {
                    isDebitValid = true;
                }
                else
                    isDebitValid = false;
                return isDebitValid;
            }
        }
    }
}
