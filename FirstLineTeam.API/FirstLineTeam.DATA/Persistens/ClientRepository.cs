using FirstLineTeam.CORE.Interfaces;
using FirstLineTeam.CORE.Models;
using FirstLineTeam.DATA.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FirstLineTeam.DATA.Persistens
{
    public class ClientRepository : IClientRepository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();
        
        public async void Create(Client client)
        {
            try
            {
                using (Context)
                {
                    Context.Client.Add(client);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async void Update(Client client)
        {
            try
            {
                using (Context)
                {
                    var update = FindbyId(client.IdClient);
                    update.Names = client.Names;
                    update.LastName = client.LastName;
                    update.Telephone = client.Telephone;
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async void Delete(int id)
        {
            try
            {
                using (Context)
                {
                    var remove = FindbyId(id);
                    Context.Client.Remove(remove);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public Client FindbyId(int Id)
        {
            using (Context)
            {
                var result = Context.Client.Where(x => x.IdClient == Id).FirstOrDefault();
                return result;
            }
        }
        public async Task<IEnumerable<Client>> GetClients()
        {
            using (Context)
            {
                var result = await Context.Client.Take(100).ToListAsync();
                return result;
            }
        }
    }
}
