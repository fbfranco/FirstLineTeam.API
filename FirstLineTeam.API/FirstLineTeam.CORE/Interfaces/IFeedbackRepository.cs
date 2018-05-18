using FirstLineTeam.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface IFeedbackRepository
    {
        void Create(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(int id);

        Task<IEnumerable<Feedback>> GetFeedbacks();
        Feedback FindbyId(int Id);
    }
}
