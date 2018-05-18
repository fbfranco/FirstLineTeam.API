using FirstLineTeam.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface ICheckListTaskRespository
    {
        void Create(CheckListTask checkListTask);
        void Update(CheckListTask checkListTask);
        void Delete(int id);

        Task<IEnumerable<CheckListTask>> GetCheckListTasks();
        CheckListTask FindbyId(int Id);
    }
}
