using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
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

      public ICommand ClosingCommand { get; set; }

      public MainWindowViewModel()
      {
         _fileController = new FileController();
         _debtorOrCreditors = new ObservableCollection<DebtorOrCreditor>();

         var savedDebtorOrCreditors = _fileController.ReadFromFile();
         _debtorOrCreditors = savedDebtorOrCreditors;

         this.ClosingCommand = new DelegateCommand<object>(this.OnWindowClosing);
      }

      ICommand _editDebitorOrCreditorCommand;

      public ICommand EditDebitorOrCreditor
      {
         get
         {
            return _editDebitorOrCreditorCommand ?? (_editDebitorOrCreditorCommand = new DelegateCommand(() =>
            {
               var vm = new DetailsMVVM(CurrentDebtorOrCreditor.DebitsList);
               var dlg = new DetailsWindow
               {
                  DataContext = vm,
                  Owner = App.Current.MainWindow
               };

               dlg.ShowDialog();

               DebtorOrCreditor updatedDebtorOrCreditor = new DebtorOrCreditor(CurrentDebtorOrCreditor.Name);
               updatedDebtorOrCreditor.DebitsList = vm.DebitsList.ToList();
               DebtorOrCreditors[CurrentIndex] = updatedDebtorOrCreditor;

            }));
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
                  DebtorOrCreditors.Add(newDebitorOrCreditor);
                  CurrentDebtorOrCreditor = newDebitorOrCreditor;
               }
            }));
         }
      }

      private void OnWindowClosing(object obj)
      {
         _fileController.WriteToFile(DebtorOrCreditors);
      }
   }
}
