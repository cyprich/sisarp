using System.Text;

namespace UnizaAddressBook.CommonLibrary
{
    public class SearchResult
    {
        public Employee[] Employees { get; }

        public SearchResult(Employee[] employees)
        {
            Employees = employees;
        }

        public void SaveToCsv(FileInfo csvFile, string delimiter = "\t")
        {
            // Kod pre univerzalne ulozenie podla definovania stlpcov
            string[]? columns = default;

            // Pre jednoduchosť netreba riešiť veľkosť písmen stĺpcov
            var allProperties = new[] { nameof(Employee.Name), nameof(Employee.MainWorkplace), nameof(Employee.Workplace), nameof(Employee.Room), nameof(Employee.Phone), nameof(Employee.Email), nameof(Employee.Position) }; //, nameof(Person.Phone), nameof(Person.Department) };
            if (columns == default || columns.Length == 0)
                columns = allProperties;

            var result = new StringBuilder();

            // Zapíšeme hlavičku
            result.AppendLine(string.Join(delimiter, columns));

            // Zapíšeme záznamy
            foreach (var employee in Employees)
            {
                foreach (var column in columns)
                {
                    switch (column)
                    {
                        case nameof(employee.Name):
                            result.Append($"{employee.Name}{delimiter}");
                            break;
                        case nameof(employee.Position):
                            result.Append($"{employee.Position}{delimiter}");
                            break;
                        case nameof(employee.Phone):
                            result.Append($"{employee.Phone}{delimiter}");
                            break;
                        case nameof(employee.Email):
                            result.Append($"{employee.Email}{delimiter}");
                            break;
                        case nameof(employee.Room):
                            result.Append($"{employee.Room}{delimiter}");
                            break;
                        case nameof(employee.MainWorkplace):
                            result.Append($"{employee.MainWorkplace}{delimiter}");
                            break;
                        case nameof(employee.Workplace):
                            result.Append($"{employee.Workplace}{delimiter}");
                            break;
                    }
                }

                result.AppendLine();
            }

            File.WriteAllText(csvFile.FullName, result.ToString());
        }
    }
}
