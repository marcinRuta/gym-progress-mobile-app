using DataBaseApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Domain.Daos
{
    public class UserCredentials : Entity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public User UserDetails { get; private set; }

        public UserCredentials(int id, string username, string password) : base(id)
        {
            Username = username;
            Password = password;
        }

        public void AddUser(User user)
        {
            this.UserDetails = user;
        }
    }
}
