using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheDebtBook.DTO;
using TheDebtBook.ViewModels;
using System.Text.RegularExpressions;

namespace TheDebtBook.Views
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as AddViewModel;

            if (!viewModel.IsNameValid)
                MessageBox.Show("Please enter a name");
            else if (!viewModel.IsDebitValid)
                MessageBox.Show("Debit must be a number");
            else
            {
                var debitSum = Convert.ToDouble(viewModel.NewDebit);
                var newDebit = new Debit(DateTime.Now.Date, debitSum);
                viewModel.NewDebtorOrCreditor.DebitsList.Add(newDebit);
                DialogResult = true;
            }
        }
    }
}
