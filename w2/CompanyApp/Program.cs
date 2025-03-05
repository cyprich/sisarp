namespace CompanyApp;

class Program
{
    static void Main(string[] args)
    {
        Company c = new Company();

        c.AddEmployee(new Employee(1, "Jozko", "Markvicka", 1, 1, 2003));
        c.AddEmployee(new Employee(2, "Jurko", "Kalerab", 2, 2, 2004));
        c.AddEmployee(new Employee(3, "Dezino", "Pomaranc", 3, 3, 2005));
        c.ListEmployees();

        c.AddProduct(new Product("Apple", 0.99m, 10, true));
        c.AddProduct(new Product("Water", 4.99m, 3, true));
        c.AddProduct(new Product("Lamp", 30m, 100, false));
        c.ListProducts();
    }
}
