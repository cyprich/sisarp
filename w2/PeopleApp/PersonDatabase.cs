namespace PeopleApp;

class PersonDatabase
{
    private List<Person> _people = new List<Person>();

    public void Add(Person person)
    {
        _people.Add(person);
    }

    public void Add(params Person[] people)
    {
        foreach (var p in people)
        {
            _people.Add(p);
        }
    }

    public List<Person> Find(string text, Gender? gender = null)
    {
        var result = new List<Person>();

        foreach (var p in _people)
        {
            if (
                (p.FirstName == text || p.LastName == text) &&
                (gender != null ? (p.Gender == gender) : (true))
            )
            {
                result.Add(p);
            }
        }

        return result;
    }

    public void PrintToConsole()
    {
        foreach (var p in _people)
        {
            System.Console.WriteLine(p);
        }
    }

    public void Remove(Person person)
    {
        _people.Remove(person);
    }
}
