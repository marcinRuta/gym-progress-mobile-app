using DataBaseApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Domain.Daos
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public IList<TrainingSession> TrainingSessions { get; private set; } = new List<TrainingSession>();

        public User(int id, string name, string surname, string email) : base(id)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
        public void AddTrainingSession(TrainingSession session)
        {
            TrainingSessions.Add(session);
        }
        public void AddTrainingSessions(IEnumerable<TrainingSession> sessions)
        {
            foreach (var session in sessions)
            {
                TrainingSessions.Add(session);
            }
        }


    }
}
