using System.Collections.Generic;

namespace FirstLineTeam.CORE.Models
{
    public class Client : Person
    {
        public int IdClient { get; set; }
        public ICollection<Project> projects { get; set; }
    }
}
