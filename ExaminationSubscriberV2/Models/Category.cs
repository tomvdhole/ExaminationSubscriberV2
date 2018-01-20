using System.Collections.Generic;

namespace ExaminationSubscriberV2.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string TypeOfParticipants { get; set; }

        public string ExaminationType { get; set; }

        public List<Participant> Participants { get; set; }
    }
}