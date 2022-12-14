using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    public class ContactMethodDisplayModel : INotifyPropertyChanged
    {
        private bool _isSelected;
        private string _contactMethodType;
        private string _contactMethodValue;

        public int ContactMethodId { get; set; }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
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
                OnPropertyChanged(nameof(ContactMethodType));
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
                OnPropertyChanged(nameof(ContactMethodValue));
            }
        }

        public int MyProperty { get; set; }

        public ContactMethodDisplayModel()
        {

        }

        public ContactMethodDisplayModel(bool isSelected, string contactMethodType, string contactMethodValue)
        {
            IsSelected = isSelected;
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
