using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApi.Application.Dtos
{
    public class ExcersiseSessions
    {

        public string ExcersiseName { get;  set; }

        public List<ExcersiseSets> ExersiseSets { get;  set; } = new List<ExcersiseSets>();


        public void AddSet(ExcersiseSets set)
        {
            ExersiseSets.Add(set);
        }
        public void AddSets(List<ExcersiseSets> sets)
        {
            foreach (var set in sets)
            {
                ExersiseSets.Add(set);
            }
        }
    }
}
