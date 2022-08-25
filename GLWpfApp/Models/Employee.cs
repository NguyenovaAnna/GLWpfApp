using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLWpfApp.Models
{
    public class Employee : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private int _employeeNumber;
        private int _nationalIdNumber;
        private int _previousIdNumber;
        private int _personellNumber;
        private DateTime _activationTime;
        private DateTime _expirationTime;

        public string FirstName
        {
            get 
            { 
                return _firstName; 
            }
            set 
            { 
                _firstName = value;
                OnPropertyChanged("FirstName");
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
                OnPropertyChanged("LastName");
            }
        }

        public string? MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                _middleName = value;
                OnPropertyChanged("MiddleName");
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
                OnPropertyChanged("EmployeeNumber");
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
                OnPropertyChanged("NationalIdNumber");
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
                OnPropertyChanged("PreviousIdNumber");
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
                OnPropertyChanged("PersonellNumber");
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
                OnPropertyChanged("ActivationTime");
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
                OnPropertyChanged("ExpirationTime");
            }
        }

        public Employee()
        {

        }

        public Employee(string firstName, string lastName, int employeeNumber, string middleName, int nationalIdNumber, int previousIdNumber, int personellNumber, DateTime activationTime, DateTime expirationTime)
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
