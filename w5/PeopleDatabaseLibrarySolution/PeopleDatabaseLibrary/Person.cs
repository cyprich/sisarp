namespace PeopleDatabaseLibrary;

// TODO 3.14: Implementujte rozhranie IComparable explicitne a IComparable<Person> implicitne
// Porovnajte priezviska, mena, pohlavie a datum narodenia. Metóda vracia 0, ak sa objekty rovnajú. V inom prípade kladné alebo záporné číslo - pozrite si dokumentáciu.
//public class Person : IComparable, IComparable<Person>
public class Person : IComparable, IComparable<Person>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
		
	public string FullName => $"{FirstName} {LastName}";

    // TODO 3.02: Pridajte metódu GetFullName(), ktorá bude vracať n-ticu (tuple) zloženú z mena a priezviska, pričom priezvisko bude s veľkými písmenami

    public string[] GetFullName() => [FirstName, LastName];

    // TODO 3.03: V konzolovej aplikácii použite túto metódu na získanie hodnôt a vypíšte najskôr priezvisko a potom meno osoby


    public DateTime? Birthdate { get; set; } // Je to rovnaké ako: public Nullable<DateTime> Birthdate { get; set; }
		
	public int Age
	{
		get
		{
			var birthday = Birthdate;
			if (!birthday.HasValue)
				return 0;		

			var today = DateTime.Today;
			var age = today.Year - birthday.Value.Year;
			if (today.Month < birthday.Value.Month || today.Month == birthday.Value.Month && today.Day < birthday.Value.Day)
				age--;

			return age;
		} 
	}
		
	public Gender Gender { get; set; }

    // TODO 3.04: Vytvorte dekonštruktor, ktorý vráti meno, priezvisko a pohlavie 

	public void Deconstruct(out string firstName, out string lastName, out Gender gender)
	{
		(firstName, lastName, gender) = (FirstName, LastName, Gender);
	}

    // TODO 3.05: Otestujte dekonštruktor v programe


    // TODO 3.06: Vytvorte druhý preťažený dekonštruktor, ktorý vráti meno, priezvisko, dátum narodenia, pohlavie a vek
	public void Deconstruct(out string firstName, out string lastName, out DateTime? birthDate, out Gender gender, out int age)
	{
        (firstName, lastName, birthDate, gender, age) = (FirstName, LastName, Birthdate, Gender, Age);
	}
    // TODO 3.07: Otestujte dekonštruktor v programe


    public Person()
	{
		FirstName = string.Empty;
		LastName = string.Empty;
	}

	// TODO 3.01: Prerobte konštruktor na jednoriadkový s použitím syntaxe n-tíc
	public Person(string firstName, string lastName, DateTime? birthday, Gender gender = Gender.Unknown)
	{
        (FirstName, LastName, Birthdate, Gender) = (firstName, lastName, birthday, gender);
	}

	public override string ToString()
	{
		return $"{FirstName} {LastName}, {Birthdate:dd.MM.yyyy}, age: ({Age}), gender: {Gender}";
	}

	/// <inheritdoc />
	public override bool Equals(object? obj)
	{
		return obj is Person person &&
			   FirstName == person.FirstName &&
			   LastName == person.LastName &&
			   Birthdate == person.Birthdate &&
			   Gender == person.Gender;
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return HashCode.Combine(FirstName, LastName, Birthdate, Gender);
	}

    public int CompareTo(object? obj)
    {
		return obj is Person ? this.CompareTo((Person) obj) : 1;
    }

    public int CompareTo(Person? other)
    {
		if (other.FirstName != FirstName)
		{
			return 1;
		}

		if (other.LastName != LastName)
		{
			return 1;
		}

		if (other.Birthdate != Birthdate)
		{
			return 1;
		}

		if (other.Gender != Gender)
		{
			return 1;
		}

		return 0;
    }
}
