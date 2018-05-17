using System;

namespace FirstLineTeam.CORE.Models
{
    public class Taskk
    {
        public int IdTask { get; set; }
        public int IdFeedback { get; set; }
        public string NameTask { get; set; }
        public string DescriptionTask { get; set; }
        public DateTime TaskStart { get; set; }
        public DateTime TaskEnd { get; set; }
        public int State { get; set; }

        public Feedback feedback { get; set; }
    }
}
