using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.DTO
{
    public class PhonebookResponse : PhonebookRequest
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string Commune { get; set; }
        public string CitySub { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
