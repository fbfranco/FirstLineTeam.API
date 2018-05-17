using FirstLineTeam.CORE.Models;
using System.Collections.Generic;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface ICheckListTaskRespository
    {
        void Create(CheckListTask checkListTask);
        void Update(CheckListTask checkListTask);
        void Delete(int id);

        IEnumerable<CheckListTask> GetCheckListTasks();
        CheckListTask FindbyId(int Id);
    }
}
