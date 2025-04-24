using System.ComponentModel;

namespace UnizaAddressBook.CommonLibrary
{
    public record class Employee : INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string position = string.Empty;
        private string? phone;
        private string email = string.Empty;
        private string? room;
        private string? mainWorkplace;
        private string? workplace;

        /// <summary>
        /// Meno aj so vsetkymi titulmi
        /// </summary>
        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        /// <summary>
        /// Ak je prazdna, je to "zamestnanec". Ak nie je prazdna, potom je to v v popise
        /// </summary>
        public string Position
        {
            get => position; set
            {
                position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        /// <summary>
        /// Telefonne cislo.
        /// </summary>
        public string? Phone
        {
            get => phone; set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        /// <summary>
        /// E-mail
        /// </summary>
        public string Email
        {
            get => email; set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        /// <summary>
        /// Miestnost
        /// </summary>
        public string? Room 
        { 
            get => room; 
            set 
            {
                room = value;
                OnPropertyChanged(nameof(Room));
            } 
        }

        /// <summary>
        /// Hlavné pracovisko
        /// </summary>
        public string? MainWorkplace
        {
            get => mainWorkplace; set
            {
                mainWorkplace = value;
                OnPropertyChanged(nameof(MainWorkplace));
            }
        }

        /// <summary>
        /// Pracovisko
        /// </summary>
        public string? Workplace
        {
            get => workplace; set
            {
                workplace = value;
                OnPropertyChanged(nameof(Workplace));
            }
        }

        public Employee()
        {
            
        }

        public Employee(string name, string position, string? phone, string email, string? room, string? mainWorkplace, string? workplace)
        {
            Name = name;
            Position = position;
            Phone = phone;
            Email = email;
            Room = room;
            MainWorkplace = mainWorkplace;
            Workplace = workplace;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
