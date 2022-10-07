using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    public class EmployeeDisplayModel : INotifyPropertyChanged
    {
        private ObservableCollection<ContactMethodDisplayModel> _contactMethods;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private int _employeeNumber;
        private int _nationalIdNumber;
        private int _previousIdNumber;
        private int _personellNumber;
        private DateTime _activationTime;
        private DateTime _expirationTime;

        public ObservableCollection<ContactMethodDisplayModel> ContactMethods
        {
            get
            {
                return _contactMethods;
            }
            set
            {
                _contactMethods = value;
                OnPropertyChanged(nameof(ContactMethods));
            }
        }

        public string FirstName
        {
            get 
            { 
                return _firstName; 
            }
            set 
            { 
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public int EmployeeNumber
        {
            get
            {
                return _employeeNumber;
            }
            set
            {
                _employeeNumber = value;
                OnPropertyChanged(nameof(EmployeeNumber));
            }
        }

        public int NationalIdNumber
        {
            get
            {
                return _nationalIdNumber;
            }
            set
            {
                _nationalIdNumber = value;
                OnPropertyChanged(nameof(NationalIdNumber));
            }
        }

        public int PreviousIdNumber
        {
            get
            {
                return _previousIdNumber;
            }
            set
            {
                _previousIdNumber = value;
                OnPropertyChanged(nameof(PreviousIdNumber));
            }
        }

        public int PersonellNumber
        {
            get
            {
                return _personellNumber;
            }
            set
            {
                _personellNumber = value;
                OnPropertyChanged(nameof(PersonellNumber));
            }
        }

        public DateTime ActivationTime
        {
            get
            {
                return _activationTime;
            }
            set
            {
                _activationTime = value;
                OnPropertyChanged(nameof(ActivationTime));
            }
        }

        public DateTime ExpirationTime
        {
            get
            {
                return _expirationTime;
            }
            set
            {
                _expirationTime = value;
                OnPropertyChanged(nameof(ExpirationTime));
            }
        }

        public EmployeeDisplayModel()
        {

        }

        public EmployeeDisplayModel(string firstName, string lastName, int employeeNumber, string middleName, int nationalIdNumber, int previousIdNumber, int personellNumber, DateTime activationTime, DateTime expirationTime, ObservableCollection<ContactMethodDisplayModel> contactMethods)
        {
            FirstName = firstName;
            LastName = lastName;
            EmployeeNumber = employeeNumber;
            MiddleName = middleName;
            NationalIdNumber = nationalIdNumber;
            PreviousIdNumber = previousIdNumber;
            PersonellNumber = personellNumber;
            ActivationTime = activationTime;
            ExpirationTime = expirationTime;
            ContactMethods = contactMethods;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
