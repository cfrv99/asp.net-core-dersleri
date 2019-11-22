using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models
{
    public class Person
    {
        public Person(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

    }
}
