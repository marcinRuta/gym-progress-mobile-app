using DataBaseApi.Domain.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApi.Application.Queries
{
    public class DataBaseQueriesHandler: IDataBaseQueriesHandler
    {
        private readonly IDataBaseRepository dataBaseRepository;

        public DataBaseQueriesHandler(IDataBaseRepository dataBaseRepository)
        {
            this.dataBaseRepository = dataBaseRepository;
        }

    }
}
