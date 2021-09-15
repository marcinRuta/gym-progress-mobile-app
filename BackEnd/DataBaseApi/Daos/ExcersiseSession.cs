using DataBaseApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Domain.Daos
{
    public class ExcersiseSession : Entity
    {
        public IList<ExcersiseSet> ExersiseSets { get; private set; } = new List<ExcersiseSet>();
        public string ExcersiseName { get; private set; }

        public ExcersiseSession(int id) : base(id)
        {

        }

        public ExcersiseSession(int id, Excersise excersise) : base(id)
        {
            ExcersiseName = excersise.ExcersiseName;
        }

        public ExcersiseSession(int id, string excersise) : base(id)
        {
            ExcersiseName = excersise;
        }

        public void AddSet(ExcersiseSet set)
        {
            ExersiseSets.Add(set);
        }
        public void AddSets(IEnumerable<ExcersiseSet> sets)
        {
            foreach(var set in sets)
            {
                ExersiseSets.Add(set);
            }
        }
    }
}
