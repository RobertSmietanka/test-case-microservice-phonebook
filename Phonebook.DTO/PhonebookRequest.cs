using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.DTO
{
    public class PhonebookRequest
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Nr { get; set; }
        public string Code { get; set; }       
    }
}
