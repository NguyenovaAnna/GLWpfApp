using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLWpfApp.Models
{
    public class ContactMethod 
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public bool IsPhoneNumberChecked { get; set; }
        public bool IsEmailChecked { get; set; }
        public bool IsSkypeChecked { get; set; }

        public ContactMethod(string phoneNumber, bool isPhoneNumberChecked, string email, bool isEmailChecked, string skype, bool isSkypeChecked)
        {
            PhoneNumber = phoneNumber;
            IsPhoneNumberChecked = isPhoneNumberChecked;
            Email = email;
            IsEmailChecked = isEmailChecked;
            Skype = skype;
            IsSkypeChecked = isSkypeChecked;
        }
    }
}
