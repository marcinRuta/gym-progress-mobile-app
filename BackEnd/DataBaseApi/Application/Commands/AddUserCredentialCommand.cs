using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApi.Application.Commands
{
    public class AddUserCredentialCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
