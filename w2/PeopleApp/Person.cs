namespace PeopleApp
{
    internal class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; }

        /*public Person()*/
        /*{*/
        /*}*/

        public Person(string firstName, string lastName, DateTime? birthday, Gender gender = Gender.Unknown)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday ?? DateTime.Today;
            Gender = gender;

            Age = DateTime.Today.Year - Birthday.Year;
            if (Birthday.Date > DateTime.Today.AddYears(-Age)) Age--;
        }

        public override bool Equals(object? obj)
        {
            return obj is Person other &&
                FirstName == other.FirstName &&
                LastName == other.LastName &&
                Birthday == other.Birthday &&
                Gender == other.Gender;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Birthday, Gender);
        }

        public override string? ToString()
        {
            return $"{FullName}, {Birthday:dd.MM.yyyy}, age: {Age}, gender: {Gender}";
        }
    }
}
