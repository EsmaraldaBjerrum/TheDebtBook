using System;
using System.Collections.ObjectModel;
using System.Windows;
using TheDebtBook.DTO;

namespace TheDebtBook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DetailsWindow window = new DetailsWindow();
            window.Show();
        }
    }
}
