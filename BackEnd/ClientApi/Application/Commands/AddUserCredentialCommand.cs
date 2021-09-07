using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Application.Commands
{
    public class AddUserCredentialCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AddUserCredentialCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
