using System.Net.Http;
using System.Windows;

namespace AsyncWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new();
        private CancellationTokenSource? _cts;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnAsync_Click(object sender, RoutedEventArgs e)
        {
            _cts = new CancellationTokenSource();
            txtStatus.Text = "Sťahujem...";
            try
            {
                string html = await _httpClient.GetStringAsync("https://httpstat.us/200?sleep=3000", _cts.Token);
                txtResult.Text = $"Výsledok: {html.Length} znakov";
                txtStatus.Text = "Hotovo!";
            }
            catch (TaskCanceledException)
            {
                txtStatus.Text = "Zrušené používateľom.";
            }
            catch (Exception ex)
            {
                txtStatus.Text = $"Chyba: {ex.Message}";
            }
        }

        private void BtnBlocking_Click(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = "Sťahujem... (blokuje UI)";
            try
            {
                string html = _httpClient.GetStringAsync("https://httpstat.us/200?sleep=3000").Result; // blokovanie!
                txtResult.Text = $"Výsledok: {html.Length} znakov";
                txtStatus.Text = "Hotovo!";
            }
            catch (Exception ex)
            {
                txtStatus.Text = $"Chyba: {ex.Message}";
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            _cts?.Cancel();
        }

        private void MandelbrotButton_Click(object sender, RoutedEventArgs e)
        {
            var mandelbrotWindow = new MandelbrotWindow();
            mandelbrotWindow.Show();
        }
    }
}