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
    }
}
