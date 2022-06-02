using App.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace App
{
    public sealed partial class OperationsHistory : UserControl
    {
        public OperationHistoryViewModel ViewModel;
        public OperationsHistory()
        {
            this.InitializeComponent();
            ViewModel = new OperationHistoryViewModel(true);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ResetOperations();
        }
        private void save_handler(object sender, RoutedEventArgs e)
        {
            ViewModel.SendOperations();
        }
    }
}
