using FirstLineTeam.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface IDeveloperRepository
    {
        void Create(Developer Developer);
        void Update(Developer Developer);
        void Delete(int id);

        Task<IEnumerable<Developer>> GetDevelopers();
        Developer FindbyId(int Id);
    }
}
