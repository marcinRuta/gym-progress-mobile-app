using DataBaseApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Domain.Daos
{
    public class Excersise : Entity
    {
        public string ExcersiseName { get; private set; }

        public Excersise(int id, string excersiseName) : base(id)
        {
            ExcersiseName = excersiseName;
        }

        
    }
}
