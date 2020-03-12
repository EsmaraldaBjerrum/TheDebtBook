using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TheDebtBook.DTO;

namespace TheDebtBook
{

   public class DetailsMVVM : BindableBase
   {
      public ObservableCollection<Debit> DebitsList { get; set; }

      public DetailsMVVM(List<Debit> debitsList)
      {
         DebitsList = new ObservableCollection<Debit>();
         DebitsList.AddRange(debitsList);
      }

      public DetailsMVVM()
      {
         DebitsList = new ObservableCollection<Debit>();
      }

      private string _value = "";

      public string Value
      {
         get
         {
            return _value;
         }
         set
         {
            _value = value.Replace('.', ',');
            RaisePropertyChanged();
         }
      }

      ICommand _addDebit;

      public ICommand AddDebit
      {
         get { return _addDebit ?? (_addDebit = new DelegateCommand(ExecuteAddDebit)); }
      }
      void ExecuteAddDebit()
      {
         double value;
         if (Value != "" && double.TryParse(Value, out value))
         {
            DebitsList.Add(new Debit(DateTime.Now.Date, value));
            Value = "";
         }
         else
            Value = "Debit must be a number";

      }
   }
}
