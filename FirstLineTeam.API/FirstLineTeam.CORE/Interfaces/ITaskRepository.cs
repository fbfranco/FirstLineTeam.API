using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface ITaskRepository
    {
        void Create(Task task);
        void Update(Task task);
        void Delete(int id);

        IEnumerable<Task> GetTasks();
        Task FindbyId(int Id);
    }
}
