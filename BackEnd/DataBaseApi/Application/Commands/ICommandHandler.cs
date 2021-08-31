using DataBaseApi.Application.Dtos;
using DataBaseApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApi.Application.Commands
{
    public interface ICommandHandler
    {
        void Handle(ICommand command);
        Response RegisterUser(AddUserCredentialCommand credentialCommand);
        Response AddUserDetails(AddUserDetailsCommand detailsCommand, UserCredential credentials);

    }


}