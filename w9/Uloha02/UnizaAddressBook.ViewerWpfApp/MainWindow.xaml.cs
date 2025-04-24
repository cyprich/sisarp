using UnizaAddressBook.CommonLibrary;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace UnizaAddressBook.ViewerWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeList? _employees;
        private SearchResult? _searchResult;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // DONE: Nacitat data JSON suboru pomocou EmployeeList.LoadFromJson
                FileInfo file = new("employees.json");
                var _employees = EmployeeList.LoadFromJson(file);
                
                PositionComboBox.ItemsSource = _employees.GetPositions();
                WorkplaceComboBox.ItemsSource = _employees.GetMainWorkplaces();
            }
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (_employees is null)
                return;

            var mainWorkplace = WorkplaceComboBox.SelectedItem as string;
            var position = PositionComboBox.SelectedItem as string;
            var name = NameTextBox.Text.Trim();

            _searchResult = _employees.Search(mainWorkplace, position, name);
            FindedEmployeeListBox.ItemsSource = _searchResult.Employees;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            NameTextBox.Clear();
            PositionComboBox.SelectedIndex = -1;
            WorkplaceComboBox.SelectedIndex = -1;
            FindedEmployeeListBox.ItemsSource = null;
        }

        private void ExportToCsvButton_Click(object sender, RoutedEventArgs e)
        {
            if (_searchResult is null || _searchResult.Employees.Length == 0)
            {
                return;
            }

            SaveFileDialog saveFileDialog = new()
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                // TODO: Vysledky _searchResult ulozit do CSV suboru vybraneho dialogovym oknom

            }
        }
    }
}
