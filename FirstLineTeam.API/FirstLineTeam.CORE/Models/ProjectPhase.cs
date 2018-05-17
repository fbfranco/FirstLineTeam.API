using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLineTeam.CORE.Models
{
    public class ProjectPhase
    {
        public int IdProjectPhase{ get; set; }
        public int IdProject { get; set; }
        public int IdCheckListTask { get; set; }
        public string NamePhase { get; set; }
        public string DescriptionPhase { get; set; }
        public DateTime EstimatedDate { get; set; }

        public Project project { get; set; }
        public ICollection<CheckListTask> checkListTasks { get; set; }
    }
}
