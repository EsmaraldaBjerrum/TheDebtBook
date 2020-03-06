using System;

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
    }
}
