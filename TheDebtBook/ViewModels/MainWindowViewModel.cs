using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using TheDebtBook.DTO;
using System.Collections.Generic;
using TheDebtBook.Data;
using TheDebtBook.DTO;

namespace TheDebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
       private ObservableCollection<DebtorOrCreditor> _debtorOrCreditors;

        private string _title = "My debt book";
        AddWindow addWindow;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ObservableCollection<DebtorOrCreditor> DebtorOrCreditors
        {
           get { return _debtorOrCreditors; }
           set { SetProperty(ref _debtorOrCreditors, value); }
        }


        public MainWindowViewModel()
        {
           _debtorOrCreditors = new ObservableCollection<DebtorOrCreditor>();
           _debtorOrCreditors.Add(new DebtorOrCreditor( {Name = "Bettina", Sum = 55.5}))
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
