using DataBaseApi.Application.Dtos;
using DataBaseApi.Commands;
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


            var id = dataBaseRepository.CheckAndReturnUsernamePasswordCombination(userCredentials.Username, userCredentials.Password);
            if (id != 0)
            {
                var failedResponse = new Response("Already registered");

                return failedResponse;
            }
            else
            {
                dataBaseRepository.AddUserCredentials(userCredentials);
                var response = new Response("Succesufully registered");

                return response;
            }
        }

        public Response AddUserDetails(AddUserDetailsCommand userDetailsCommand, UserCredential credentials)
        {
            var id = dataBaseRepository.CheckAndReturnUsernamePasswordCombination(credentials.Username, credentials.Password);
            if (id == 0)
            {
                var failedResponse = new Response("Wrong credentials");

                return failedResponse;
            }

            var userDetails = new Users(0, userDetailsCommand.Name, userDetailsCommand.Surname, userDetailsCommand.Email, userDetailsCommand.TelephoneNumber);
            dataBaseRepository.AddUserDetails(userDetails, id);
            var response = new Response("Succesufully updated details");

            return response;
        }
    }
}
