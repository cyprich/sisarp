namespace PeopleApp;

class Program
{
    static void Main(string[] args)
    {
        /*Person p = new("Jozko", "Mrkvicka", new DateTime(2003, 12, 24), Gender.Male);*/
        PersonDatabase db = new();
        db.Add(new Person("Jozko", "Mrkvicka", new DateTime(2003, 12, 24), Gender.Male));
        db.Add(new Person("Peter", "Cyprich", new DateTime(2003, 6, 4), Gender.Male));
        db.Add(new Person("Ferko", "Ferkovic", new DateTime(2025, 1, 1), Gender.Female));
        db.Add(new Person("Nikto", "Niktos", new DateTime(1999, 1, 23), Gender.Unknown));

        db.PrintToConsole();
    }
}
