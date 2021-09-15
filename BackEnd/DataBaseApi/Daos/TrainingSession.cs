using DataBaseApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Domain.Daos
{
    public class TrainingSession : Entity
    {
        public DateTime Date { get; private set; }
        public IList<ExcersiseSession> ExcersiseSessions { get; private set; } = new List<ExcersiseSession>();

        public TrainingSession(int id, DateTime date) : base(id)
        {
            Date = date;
        }

        public void AddSession(ExcersiseSession session)
        {
            ExcersiseSessions.Add(session);
        }

        public void AddSessions(IEnumerable<ExcersiseSession> sessions)
        {
            foreach(var session in sessions)
            {
                ExcersiseSessions.Add(session);
            }
        }
    }

}
