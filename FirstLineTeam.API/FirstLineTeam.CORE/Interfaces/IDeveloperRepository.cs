using FirstLineTeam.CORE.Models;
using System.Collections.Generic;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface IDeveloperRepository
    {
        void Create(Developer Developer);
        void Update(Developer Developer);
        void Delete(int id);

        IEnumerable<Developer> GetDevelopers();
        Developer FindbyId(int Id);
    }
}
