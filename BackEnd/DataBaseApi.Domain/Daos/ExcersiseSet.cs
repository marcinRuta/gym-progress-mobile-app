using DataBaseApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Domain.Daos
{
    public class ExcersiseSet : Entity
    {
        public string Weight { get; private set; }
        public string Repetitions { get; private set; }

        public ExcersiseSet(int id, string weight, string repetitions) : base(id)
        {
            Weight = weight;
            Repetitions = repetitions;
        }

    }
}
