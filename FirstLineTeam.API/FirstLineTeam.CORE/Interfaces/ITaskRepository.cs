using FirstLineTeam.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface ITaskRepository
    {
        void Create(Taskk task);
        void Update(Taskk task);
        void Delete(int id);

        Task<IEnumerable<Taskk>> GetTasks();
        Taskk FindbyId(int Id);
    }
}
