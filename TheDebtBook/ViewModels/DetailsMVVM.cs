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
        public DebtorOrCreditor _debtorOrCreditor { get; set; }

        public DetailsMVVM(DebtorOrCreditor debtorOrCreditor)
        {
            _debtorOrCreditor = debtorOrCreditor;
        }


        private string value = "";

        private DelegateCommand _addDebtorOrCreditor;
        public DelegateCommand CommandName =>
            _addDebtorOrCreditor ?? (_addDebtorOrCreditor = new DelegateCommand(ExecuteCommandName, CanExecuteCommandName));

        void ExecuteCommandName()
        {
            _debtorOrCreditor.DebitsList.Add(new Debit(DateTime.Today, Convert.ToDouble(value)));
        }

        bool CanExecuteCommandName()
        {
            return true;
        }
    }
}
