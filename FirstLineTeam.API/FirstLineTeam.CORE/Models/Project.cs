using System.Collections.Generic;

namespace FirstLineTeam.CORE.Models
{
    public class Project
    {
        public int IdProject { get; set; }
        public string NameProject { get; set; }
        public int IdClient { get; set; }
        public int IdDeveloper { get; set; }

        public Client client { get; set; }
        public Developer developer { get; set; }
        public ICollection<Feedback> feedbacks { get; set; }
        public ICollection<ProjectPhase> projectPhases { get; set; }
    }
}
