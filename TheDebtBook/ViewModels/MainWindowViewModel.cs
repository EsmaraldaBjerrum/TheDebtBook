using System;
using System.Collections.Generic;
using TheDebtBook.Data;
using TheDebtBook.DTO;

namespace TheDebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
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
    }
}
