namespace Uniza.CSharp.Lab.Delegates
{
    // DONE: Úloha 1.01 - vytvorte si vlastného delegáta s názvom PersonToString, ktorého návratový typ bude string a vstupný parameter bude Person 
    public delegate string PersonToString(Person person);
    //Func<Person, string>;

    public class PeopleDatabase
    {
        private readonly List<Person> _people;

        public PeopleDatabase(IEnumerable<Person> people) => _people = new List<Person>(people);

        public void WriteToConsole(bool includeFirstName = true)
        {
            // Príklad použitia premennej delegátového typu Action<Person>
            Action<Person> action;

            // 1. možnosť - priradenie metód (odkazov na metódy - všimnite si zápis metód bez zátvoriek na konci)
            if (includeFirstName)
                action = WritePersonFullNameToConsole;
            else
                action = WritePersonLastNameToConsole;

            //// 2. možnosť - priradenie anonymných delegátov (metóda nemá meno, telo je definované vo vnútri, v súčasnosti sa tento zápis už nepoužíva)
            //if (includeFirstName)
            //{
            //    action = delegate (Person p)
            //    {
            //        Console.WriteLine($"{p.FirstName} {p.LastName?.ToUpper()} ({p.Birthday:dd.MM.yyyy})");
            //    };
            //}
            //else
            //{
            //    action = delegate (Person p)
            //    {
            //        Console.WriteLine($"{p.LastName} ({p.Birthday:dd.MM.yyyy})");
            //    };
            //}

            //// 3. možnosť - priradenie lambda výrazov (anonymná metóda bez mena s lambda operátorom "rakety" =>)
            //if (includeFirstName)
            //    action = p => Console.WriteLine($"{p.FirstName} {p.LastName?.ToUpper()} ({p.Birthday:dd.MM.yyyy})");
            //else
            //    action = p => Console.WriteLine($"{p.LastName} ({p.Birthday:dd.MM.yyyy})");

            // Vykoná pre každú položku zo zoznamu definovanú akciu
            _people.ForEach(action);

            static void WritePersonFullNameToConsole(Person p)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName?.ToUpper()} ({p.Birthdate:dd.MM.yyyy})");
            }

            static void WritePersonLastNameToConsole(Person p)
            {
                Console.WriteLine($"{p.LastName} ({p.Birthdate:dd.MM.yyyy})");
            }
        }

        // Done: Úloha 1.02 - vytvorte novú metódu WriteToConsole(PersonToString personFormatting): void, ktorá vypíše osoby z fieldu _people na konzolu zavolaním personFormatting()
        //public void WriteToConsole(PersonToString personFormatting)
        //{
        //    foreach (var p in _people)
        //    {
        //        Console.WriteLine(personFormatting(p));
        //    }
        //}

        // DONE: Úloha 1.04 - zmeňte v metóde WriteToConsole vstupný delegát PersonToString za vstavaný delegát Func<T, TResult>, pričom za T a TResult nahraďte zodpovedajúce typy ako sú definované v delegátovi PersonToString 
        // Action - navratovy typ vzdy void
        public void WriteToConsole(Func<Person, string> personFormatting)
        {
            foreach (var p in _people)
            {
                Console.WriteLine(personFormatting(p));
            }
        }

        // DONE: Úloha 1.05 - preskúmajte delegáta Comparison<T> (F12 a F1 nad parametrom)
        public void Sort(Comparison<Person> comparison) => _people.Sort(comparison);

        // DONE: Úloha 1.08 - implementujte metódu FindByLastName(string lastName): List<Person>, ktorá vráti zoznam osôb, ktorých priezviská začínajú na hľadaný reťazec
        public List<Person> FindByLastName(string lastName)
        {
            //var result = new List<Person>();

            //foreach (var p in _people)
            //{
            //    if (p.LastName.StartsWith(lastName))
            //    {
            //        result.Add(p);
            //    }
            //}

            //return result;

            return _people.FindAll(p => p.LastName.StartsWith(lastName));
        }

        // DONE: Úloha 1.10 - implementujte metódu, ktorá vráti priemerný vek všetkých osôb v databáze
        public double GetAverageAge()
        {
            double result = 0;
            var today = DateTime.Today.Year;

            foreach (var p in _people)
            {
                result += today - p.Birthdate.Year;
            }

            return result / _people.Count();
        }

        // DONE: Úloha 1.12 - implementujte metódu, ktorá vráti enumerovateľnú kolekciu osôb utriedenú podľa priezviska zostupne a podľa mena vzostupne
        public IEnumerable<Person> GetSortedPeopleByName()
        {
            return _people.OrderByDescending(p => p.LastName).ThenBy(p => p.FirstName);
        }
    }
}
