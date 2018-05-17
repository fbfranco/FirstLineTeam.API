using System;
using System.Collections.Generic;

namespace FirstLineTeam.CORE.Models
{
    public class Feedback
    {
        public int IdFeedback { get; set; }
        public int IdProject { get; set; }
        public DateTime DateRequest { get; set; }
        public string Comment { get; set; }

        public Project project { get; set; }
        public ICollection<Taskk> taskks { get; set; }
    }
}
