using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using TheDebtBook.DTO;
using System.Collections.Generic;
using System.Windows.Documents;
using TheDebtBook.Data;
using TheDebtBook.Views;

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
           _debtorOrCreditors.Add(new DebtorOrCreditor("Bettina",5.5));
        }
    }
}
