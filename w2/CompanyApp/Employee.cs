namespace CompanyApp
{
    public class Employee
    {
        public int EmployeeID;
        public string FirstName = string.Empty;
        public string LastName = string.Empty;
        public DateTime DateOfBirth;
        public int Age;
        public BankAccount Account = new BankAccount();

        public Employee(int id, string firstName, string lastName, int birthDay, int birthMonth, int birthYear)
        {
            EmployeeID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = new DateTime(birthYear, birthMonth, birthDay);

            // finding out age
            DateTime today = DateTime.Today;
            Age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-Age)) Age--;
        }

        public string GetEmployeeInfo()
        {
            return $"{FirstName} {LastName}, ID: {EmployeeID}, Born: {DateOfBirth.ToString("dd.MM.yyyy")}, Age: {Age}";
        }
    }
}
