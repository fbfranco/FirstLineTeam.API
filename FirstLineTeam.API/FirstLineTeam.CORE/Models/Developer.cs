using System.Collections.Generic;

namespace FirstLineTeam.CORE.Models
{
    public class Developer : Person
    {
        public int IdDeveloper { get; set; }
        public ICollection<Project> projects { get; set; }
    }
}
