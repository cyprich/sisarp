namespace CompanyApp
{
    public class Company
    {
        private List<Employee> Employees = new List<Employee>();
        private List<Product> Products = new List<Product>();
        private BookCollection Library = new BookCollection();
        private List<Car> Cars = new List<Car>();

        public Company() { }

        public void AddEmployee(Employee e) { Employees.Add(e); }
        public void AddProduct(Product p) { Products.Add(p); }
        public void AddBook(string book) { Library.Add(book); }
        public void AddCar(Car c) { Cars.Add(c); }

        public void ListEmployees()
        {
            System.Console.WriteLine("EMPLOYEES:");
            foreach (var e in Employees)
            {
                System.Console.WriteLine(e.GetEmployeeInfo());
            }
            System.Console.WriteLine();
        }

        public void ListProducts()
        {
            System.Console.WriteLine("PRODUCTS:");
            foreach (var p in Products)
            {
                System.Console.WriteLine($"Product: {p.Name}, Price: {p.Price}, Stock: {p.Stock}, {(p.IsAvailable ? "IS available" : "IS NOT available")}");
            }
            System.Console.WriteLine();
        }
    }
}

