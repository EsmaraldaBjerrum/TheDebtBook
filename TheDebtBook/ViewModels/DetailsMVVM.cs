using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDebtBook.DTO;
using Prism.Commands;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;

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
                _value = value;
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
                Value = "Value is not correct";       
            
        }
    }
}
