namespace CompanyApp
{
    public class BookCollection
    {
        private List<string> books = new List<string>();

        public BookCollection() { }

        public void Add(string bookName)
        {
            books.Add(bookName);
        }

        public string this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
    }
}
