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
        private string _phoneNumber;
        private string _email;
        private string _skype;
        private bool _isPhoneNumberChecked;
        private bool _isEmailChecked;
        private bool _isSkypeChecked;
        
        public string PhoneNumber 
        { 
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Skype
        {
            get
            {
                return _skype;
            }
            set
            {
                _skype = value;
                OnPropertyChanged(nameof(Skype));
            }
        }
        public bool IsPhoneNumberChecked
        {
            get
            {
                return _isPhoneNumberChecked;
            }
            set
            {
                _isPhoneNumberChecked = value;
                OnPropertyChanged(nameof(IsPhoneNumberChecked));
            }
        }
        public bool IsEmailChecked
        {
            get
            {
                return _isEmailChecked;
            }
            set
            {
                _isEmailChecked = value;
                OnPropertyChanged(nameof(IsEmailChecked));
            }
        }
        public bool IsSkypeChecked
        {
            get
            {
                return _isSkypeChecked;
            }
            set
            {
                _isSkypeChecked = value;
                OnPropertyChanged(nameof(IsSkypeChecked));
            }
        }

        public ContactMethod()
        {

        }

        public ContactMethod(string phoneNumber, bool isPhoneNumberChecked, string email, bool isEmailChecked, string skype, bool isSkypeChecked)
        {
            PhoneNumber = phoneNumber;
            IsPhoneNumberChecked = isPhoneNumberChecked;
            Email = email;
            IsEmailChecked = isEmailChecked;
            Skype = skype;
            IsSkypeChecked = isSkypeChecked;
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
