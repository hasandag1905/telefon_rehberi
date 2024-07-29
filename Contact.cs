using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace telefon_rehberi
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string No { get; set; }
        public Contact(string firstName, string lastName, string no){
            this.FirstName = firstName;
            this.LastName = lastName;
            this.No = no;
        }
        public override string ToString()
    {
        return $"İsim: {FirstName}, Soyisim: {LastName}, Telefon Numarası: {No}";
    }
    }
}