using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ContactMethodDTO
    {
        public string ContactMethodType { get; set; }
        public string ContactMethodValue { get; set; }
        public bool IsSelected { get; set; }
    }
}
