using PeopleDatabaseLibrary;

var p = new Person("Jozko", "Mrkvicka", DateTime.Now.AddYears(-30), Gender.Male);

var fullName = p.GetFullName();

Console.WriteLine(fullName[0]);
Console.WriteLine(fullName[1]);

Console.WriteLine("\n----- DEKONSTRUKTOR -----");
var (firstname, lastname, gender) = p;
Console.WriteLine(firstname);
Console.WriteLine(lastname);
Console.WriteLine(gender);

Console.WriteLine("\n----- DEKONSTRUKTOR 2 -----");
var (firstname2, lastname2, date, gender2, age) = p;
Console.WriteLine(firstname2);
Console.WriteLine(lastname2);
Console.WriteLine(date);
Console.WriteLine(gender2);
Console.WriteLine(age);

Console.WriteLine("\n----- DATABAZA -----");
PersonDatabase database = new();
database.Add(PersonGenerator.Generate(50));
database.PrintToConsole();

Console.WriteLine("\n----- INDEXER -----");
Console.WriteLine(database[27]);
Console.WriteLine(database[27] = PersonGenerator.Generate(1)[0]);

Console.WriteLine("\n----- FIND -----");
Console.WriteLine(database["Adam", "Maly"]);
//database.Add(p);
//Console.WriteLine(database["Jozko", "Mrkvicka"]);
//Console.WriteLine(database.Find("Adam")[0]);