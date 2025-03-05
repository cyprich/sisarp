namespace CompanyApp
{
    public class Car
    {
        public string Model = string.Empty;
        public int Year;
        private static int TotalCars;

        public Car(string model, int year)
        {
            Model = model;
            Year = year;
            TotalCars++;
        }

        public int GetTotalCars()
        {
            return TotalCars;
        }
    }
}
