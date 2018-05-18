using FirstLineTeam.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface IClientRepository
    {
        void Create(Client client);
        void Update(Client client);
        void Delete(int id);

        Task<IEnumerable<Client>> GetClients();
        Client FindbyId(int Id);
    }
}
