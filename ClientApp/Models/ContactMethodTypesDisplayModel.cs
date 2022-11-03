using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    public class ContactMethodTypesDisplayModel : INotifyPropertyChanged
    {
        
        private string _contactMethodType;
        public int ContactMethodId { get; set; }
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

        public ContactMethodTypesDisplayModel()
        {

        }

        public ContactMethodTypesDisplayModel(int contactMethodId, string contactMethodType)
        {
            ContactMethodId = contactMethodId;
            ContactMethodType = contactMethodType;
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
