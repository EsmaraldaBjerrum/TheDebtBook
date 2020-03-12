using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using TheDebtBook.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using TheDebtBook.Data;
using TheDebtBook.Views;

namespace TheDebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
       private ObservableCollection<DebtorOrCreditor> _debtorOrCreditors;
       private readonly FileController _fileController;

        private string _title = "My debt book";
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

        DebtorOrCreditor _currentDebtorOrCreditor = null;

        public DebtorOrCreditor CurrentDebtorOrCreditor
        {
           get { return _currentDebtorOrCreditor; }
           set
           {
              SetProperty(ref _currentDebtorOrCreditor, value);
           }
        }

        int _currentIndex = -1;
        public int CurrentIndex
        {
           get { return _currentIndex; }
           set
           {
              SetProperty(ref _currentIndex, value);
           }
        }

        private bool _dirty = false;
        public bool Dirty
        {
           get { return _dirty; }
           set
           {
              SetProperty(ref _dirty, value);
           }
        }


      public MainWindowViewModel()
        {
            //var savedDebtorOrCreditors = _fileController.ReadFromFile();

            //_debtorOrCreditors = new ObservableCollection<DebtorOrCreditor>();

            //_debtorOrCreditors = savedDebtorOrCreditors;

            _debtorOrCreditors = new ObservableCollection<DebtorOrCreditor>
            {
               new DebtorOrCreditor("Bettina", 50),
               new DebtorOrCreditor("Knud", 600)
            };
        }

        ICommand _editDebitorOrCreditorCommand;
        public ICommand EditDebitorOrCreditor
        {
            get
            {
                return _editDebitorOrCreditorCommand ?? (_editDebitorOrCreditorCommand = new DelegateCommand(() =>
                   {
                       var tempCreditorOrDebitor = CurrentDebtorOrCreditor.Clone();
                       var vm = new DetailsMVVM(tempCreditorOrDebitor);
                       var dlg = new DetailsWindow { DataContext = vm, Owner = App.Current.MainWindow };
                       if (dlg.ShowDialog() == true)
                       {
                           CurrentDebtorOrCreditor.Name = tempCreditorOrDebitor.Name;
                           CurrentDebtorOrCreditor.DebitsList = tempCreditorOrDebitor.DebitsList;
                           CurrentDebtorOrCreditor.Sum = tempCreditorOrDebitor.DebitsList.Sum(item => item.DebitValue);
                       }

                       Dirty = true;
                   },
                   () =>
                   {
                       return CurrentIndex >= 0;
                   }
                ).ObservesProperty(() => CurrentIndex));
            }
        }

        ICommand _newDebitorOrCreditorCommand;

        public ICommand AddNewDebitorOrCreditorCommand
        {
            get
            {
                return _newDebitorOrCreditorCommand ?? (_newDebitorOrCreditorCommand = new DelegateCommand(() =>
                {
                    var newDebitorOrCreditor = new DebtorOrCreditor();
                    var vm = new AddViewModel("Add new debitor or creditor", newDebitorOrCreditor);

                    var dlg = new AddWindow();
                    dlg.DataContext = vm;
                    if (dlg.ShowDialog() == true)
                    {
                        //sætte debit ind her? 
                        DebtorOrCreditors.Add(newDebitorOrCreditor);
                        CurrentDebtorOrCreditor = newDebitorOrCreditor;
                    }
                    Dirty = true;
                }));
            }
        }

        private ICommand _closingCommand;

      public ICommand ClosingCommand
      {
         get
         {
            return _closingCommand ?? (_closingCommand = new
               DelegateCommand<CancelEventArgs>(ClosingCommand_Execute));
         }
      }

      private void ClosingCommand_Execute(CancelEventArgs arg)
      {
         if (Dirty)
            arg.Cancel = UserRegrets();
      }

      private bool UserRegrets()
      {
         var regret = false;
         MessageBoxResult res = MessageBox.Show("You have unsaved data. Are you sure you want to close the application without saving data first?",
            "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
         if (res == MessageBoxResult.No)
         {
            regret = true;
         }
         return regret;
      }

   }
}
