using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDebtBook.DTO;
using Prism.Commands;


namespace TheDebtBook
{ 

    public class DetailsMVVM : BindableBase
    {
        public DebtorOrCreditor DebtorOrCreditor { get; set; }

        public DetailsMVVM(DebtorOrCreditor debtorOrCreditor)
        {
            DebtorOrCreditor = debtorOrCreditor;
            DebtorOrCreditor.DebitsList.Add(new Debit(DateTime.Now.Date, 56473));
        }

        public DetailsMVVM()
        {
            DebtorOrCreditor = new DebtorOrCreditor("navn", 50);
            DebtorOrCreditor.DebitsList.Add(new Debit(DateTime.Now.Date, 56473));
        }

        private string value = "";

        private DelegateCommand _addDebtorOrCreditor;
        public DelegateCommand CommandName =>
            _addDebtorOrCreditor ?? (_addDebtorOrCreditor = new DelegateCommand(ExecuteCommandName, CanExecuteCommandName));

        void ExecuteCommandName()
        {
            DebtorOrCreditor.DebitsList.Add(new Debit(DateTime.Now.Date, Convert.ToDouble(value)));
        }

        bool CanExecuteCommandName()
        {
            return true;
        }
    }
}
