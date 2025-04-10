using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFirstWPFApp
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

        private void ShowHelloButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello WPF!", Title);
        }

        private void ChangeBackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Would you like to change background color to blue?", 
                "Change Background?", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question
            );
            Background = result == MessageBoxResult.Yes ? Brushes.DeepSkyBlue : Brushes.White;
        }
    }
}