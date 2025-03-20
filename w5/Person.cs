namespace PeopleDatabaseLibrary;

// TODO 3.14: Implementujte rozhranie IComparable explicitne a IComparable<Person> implicitne
// Porovnajte priezviska, mena, pohlavie a datum narodenia. Metóda vracia 0, ak sa objekty rovnajú. V inom prípade kladné alebo záporné číslo - pozrite si dokumentáciu.
public class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
		
	public string FullName => $"{FirstName} {LastName}";

    // TODO 3.02: Pridajte metódu GetFullName(), ktorá bude vracať n-ticu (tuple) zloženú z mena a priezviska, pričom priezvisko bude s veľkými písmenami
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
    // TODO 3.05: Otestujte dekonštruktor v programe


    // TODO 3.06: Vytvorte druhý preťažený dekonštruktor, ktorý vráti meno, priezvisko, dátum narodenia, pohlavie a vek
    // TODO 3.07: Otestujte dekonštruktor v programe


    public Person()
	{
		FirstName = string.Empty;
		LastName = string.Empty;
	}

	// TODO 3.01: Prerobte konštruktor na jednoriadkový s použitím syntaxe n-tíc
	public Person(string firstName, string lastName, DateTime? birthday, Gender gender = Gender.Unknown)
	{
		FirstName = firstName;
		LastName = lastName;
		Birthdate = birthday;
		Gender = gender;
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
}
