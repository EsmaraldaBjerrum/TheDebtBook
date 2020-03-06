using Prism.Commands;
using System;
using TheDebtBook.DTO;
using TheDebtBook.Views;

namespace TheDebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "My debt book";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private void SetProperty(ref string title, string value)
        {
            throw new NotImplementedException();
        }

        public MainWindowViewModel()
        {
            
        }


        private DelegateCommand addDebtorOrCreditorCommand;
        public DelegateCommand AddDebtorOrCreditorCommand =>
            addDebtorOrCreditorCommand ?? (addDebtorOrCreditorCommand = new DelegateCommand(ExecuteCommandName));

        void ExecuteCommandName()
        {
            //Slet ikke færdig kode
            addWindow = new AddWindow();
            DebtorOrCreditor newDebtorOrCreditor = new DebtorOrCreditor();
            addWindow.ShowDialog();
            
        }
    }
}
