using System.Collections.ObjectModel;
using System.Text.Json;

namespace UnizaAddressBook.CommonLibrary
{
    public class EmployeeList : ObservableCollection<Employee>
    {
        public static EmployeeList? LoadFromJson(FileInfo jsonFile)
        {
            using FileStream stream = File.OpenRead(jsonFile.FullName);
            return JsonSerializer.Deserialize<EmployeeList>(stream);
        }

        public void SaveToJson(FileInfo jsonFile)
        {
            var content = JsonSerializer.Serialize(this);
            File.WriteAllText(jsonFile.FullName, content);
        }       

        public IEnumerable<string> GetPositions() => this.Select(p => p.Position).Distinct().OrderBy(x => x).ToArray() ?? [];

        public IEnumerable<string> GetMainWorkplaces() => this.Where(p => p.MainWorkplace is not null).Select(p => p.MainWorkplace!).Distinct().OrderBy(x => x).ToArray() ?? [];

        public SearchResult Search(string? mainWorkplace = null, string? position = null, string? name = null)
        {
            IEnumerable<Employee> filter = this;
            
            if (mainWorkplace is not null)
                filter = filter.Where(e => e.MainWorkplace == mainWorkplace);

            if (position is not null)
                filter = filter.Where(e => e.Position == position);

            if (!string.IsNullOrWhiteSpace(name))
                filter = filter.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            return new SearchResult([.. filter]);
        }
      
    }
}
