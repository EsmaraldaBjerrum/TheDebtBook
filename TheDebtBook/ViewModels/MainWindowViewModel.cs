using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TheDebtBook.Data;
using TheDebtBook.DTO;
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
         _fileController = new FileController();

         var savedDebtorOrCreditors = _fileController.ReadFromFile();
         _debtorOrCreditors = new ObservableCollection<DebtorOrCreditor>();
         _debtorOrCreditors = savedDebtorOrCreditors;

      }

      ICommand _editDebitorOrCreditorCommand;
      public ICommand EditDebitorOrCreditor
      {
         get
         {
            return _editDebitorOrCreditorCommand ?? (_editDebitorOrCreditorCommand = new DelegateCommand(() =>
               {
                  var tempCreditorOrDebitor = CurrentDebtorOrCreditor.Clone();
                  var vm = new DetailsMVVM(tempCreditorOrDebitor.DebitsList);
                  var dlg = new DetailsWindow
                  {
                     DataContext = vm,
                     Owner = App.Current.MainWindow
                  };

                  if (dlg.ShowDialog() == true)
                  {
                     CurrentDebtorOrCreditor.Name = tempCreditorOrDebitor.Name;
                     CurrentDebtorOrCreditor.DebitsList = tempCreditorOrDebitor.DebitsList;
                     CurrentDebtorOrCreditor.Sum = tempCreditorOrDebitor.Sum;
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
                  newDebitorOrCreditor.DebitsList.Add(new Debit(DateTime.Now, newDebitorOrCreditor.Sum));
                  DebtorOrCreditors.Add(newDebitorOrCreditor);
                  CurrentDebtorOrCreditor = newDebitorOrCreditor;
               }
            }));
         }
      }

      private ICommand _closingCommand;

      public ICommand ClosingCommand
      {
         get
         {
            return _closingCommand ?? (_closingCommand = new DelegateCommand(() =>
               {
                  _fileController.WriteToFile(DebtorOrCreditors);
               }));
         }
      }
   }
}
