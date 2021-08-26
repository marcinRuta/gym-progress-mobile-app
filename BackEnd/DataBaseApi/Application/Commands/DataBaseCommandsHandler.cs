using DataBaseApi.Application.Dtos;
using DataBaseApi.Domain.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApi.Application.Commands
{
    public class DataBaseCommandsHandler :ICommandHandler
    {
        private readonly IDataBaseRepository dataBaseRepository;

        public DataBaseCommandsHandler(IDataBaseRepository dataBaseRepository){
            this.dataBaseRepository = dataBaseRepository;
        }

        public void Handle(ICommand test)
        {
            throw new NotImplementedException();
        }
        public Response RegisterUser(AddUserCredentialCommand credentialCommand)
        {
            UserCredentials userCredentials = new(1, credentialCommand.Username, credentialCommand.Password);
            dataBaseRepository.AddUserCredentials(userCredentials);
            var response = new Response("Succesufully registered");

            return  response;
        }
    }
}
