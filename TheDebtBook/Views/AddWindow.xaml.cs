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
            if (viewModel.IsNameAndDebitValid)
            {
                var newSum = viewModel.NewDebtorOrCreditor.Sum;
                var newDebit = new Debit(DateTime.Now.Date, newSum);
                //viewModel.NewDebtorOrCreditor.DebitsList.Add(newDebit);
                DialogResult = true;
            }
            else
                MessageBox.Show("Please enter both a name and a initial debit");
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
