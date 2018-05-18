using FirstLineTeam.CORE.Models;
using System.Collections.Generic;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface IProjectPhaseRepository
    {
        void Create(ProjectPhase projectPhase);
        void Update(ProjectPhase projectPhase);
        void Delete(int id);

        IEnumerable<ProjectPhase> GetProjectPhases();
        ProjectPhase FindbyId(int Id);
    }
}
