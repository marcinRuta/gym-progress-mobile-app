using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApi.Application.Dtos
{
    public class TrainingSessions
    {

        public DateTime Date { get;  set; }
        public List<ExcersiseSessions> ExcersiseSessions { get;  set; } = new List<ExcersiseSessions>();

        public void AddSession(ExcersiseSessions session)
        {
            ExcersiseSessions.Add(session);
        }

        public void AddSessions(List<ExcersiseSessions> sessions)
        {
            foreach (var session in sessions)
            {
                ExcersiseSessions.Add(session);
            }
        }

    }
}
