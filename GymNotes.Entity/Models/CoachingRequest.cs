using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Entity.Models
{
    public class CoachingRequest
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public string CoachId { get; set; }

        public DateTime Date { get; set; }

        public CoachingRequestStatus Status { get; set; }
    }
}
