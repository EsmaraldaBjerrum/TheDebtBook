﻿using System;

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

            var dwedwfwfgwefwefwefwef = 0;
            var hest = 666;
        }
    }
}
