using FirstLineTeam.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface IProjectRepository
    {
        Task Create(Project project);
        void Update(Project project);
        void Delete(int id);

        Task<IEnumerable<Project>> GetProjects();
        Project FindbyId(int Id);
    }
}
