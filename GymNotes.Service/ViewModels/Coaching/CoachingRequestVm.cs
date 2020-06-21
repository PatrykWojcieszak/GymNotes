using System;
using GymNotes.Service.Base;
using Newtonsoft.Json;

namespace GymNotes.Service.ViewModels
{
  
    public class CoachingRequestVm
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public string CoachId { get; set; }

        [JsonConverter(typeof(JsonFormatDate), "yyyy-MM-dd")]
        public DateTime Date { get; set; }

        public CoachingRequestStatus Status { get; set; }

    }
}
