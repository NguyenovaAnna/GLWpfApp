using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLWpfApp.Models
{
    public class ContactMethod : INotifyPropertyChanged
    {
        private bool _hasValue;
        private string _contactMethodType;
        private string _contactMethodValue;

        public bool HasValue
        {
            get
            {
                return _hasValue;
            }
            set
            {
                _hasValue = value;
                OnPropertyChanged("IsChecked");
            }
        }
        public string ContactMethodType 
        { 
            get
            {
                return _contactMethodType;
            }
            set
            {
                _contactMethodType = value;
                OnPropertyChanged("ContactMethodType");
            }
        }
        public string ContactMethodValue
        {
            get
            {
                return _contactMethodValue;
            }
            set
            {
                _contactMethodValue = value;
                OnPropertyChanged("ContactMethodValue");
            }
        }
        

        public ContactMethod(bool hasValue, string contactMethodType, string contactMethodValue)
        {
            HasValue = hasValue;
            ContactMethodType = contactMethodType;
            ContactMethodValue = contactMethodValue;

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
