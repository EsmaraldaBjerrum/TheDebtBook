using System.Windows;

namespace TheDebtBook
{
   /// <summary>
   /// Interaction logic for DetailsWindow.xaml
   /// </summary>
   public partial class DetailsWindow : Window
   {
      public DetailsWindow()
      {
         InitializeComponent();
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         Close();
      }
   }
}
