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
        private string _fullname;

        public string FirstName
        {
            get 
            { 
                return _firstName; 
            }
            set 
            { 
                _firstName = value;
                OnPropertyChanged(FirstName);
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
                OnPropertyChanged(LastName);
            }
        }


        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
                ph(this, new PropertyChangedEventArgs(p));
        }
    }
}
