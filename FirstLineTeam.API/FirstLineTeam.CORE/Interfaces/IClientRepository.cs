using FirstLineTeam.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstLineTeam.CORE.Interfaces
{
    public interface IClientRepository
    {
        Task Create(Client client);
        Task Update(Client client);
        Task Delete(int id);

        Task<IEnumerable<Client>> GetClients();
        Task<Client> FindbyId(int Id);
    }
}
