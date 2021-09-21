using DataBaseApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Domain.Daos
{
    public class Users : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string TelephoneNumber { get; private set; }
        public IList<TrainingSession> TrainingSessions { get; private set; } = new List<TrainingSession>();

        public Users(int Id, string Name, string Surname, string Email, string TelephoneNumber) : base(Id)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.TelephoneNumber = TelephoneNumber;
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
