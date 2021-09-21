using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Application.Dtos
{
    public class UserDetails
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }

        public UserDetails(string name, string surname, string email, string telephoneNumber)
        {
            Name = name;
            Surname = surname;
            Email = email;
            TelephoneNumber = telephoneNumber;
        }
    }
}
