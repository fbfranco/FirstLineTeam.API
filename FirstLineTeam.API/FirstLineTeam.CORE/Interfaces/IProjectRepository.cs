using FirstLineTeam.CORE.Models;
using System.Collections.Generic;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface IProjectRepository
    {
        void Create(Project project);
        void Update(Project project);
        void Delete(int id);

        IEnumerable<Project> GetProjects();
        Project FindbyId(int Id);
    }
}
