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
        FirstLineTeamDbContext Context;
        
        public async Task Create(Client client)
        {
            try
            {
                using (Context = new FirstLineTeamDbContext())
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
        public async Task Update(Client client)
        {
            try
            {
                var update = await FindbyId(client.IdClient);
                using (Context = new FirstLineTeamDbContext())
                {
                    update.Names = client.Names;
                    update.LastName = client.LastName;
                    update.Telephone = client.Telephone;

                    Context.Entry(update).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                var remove = await FindbyId(id);
                using (Context = new FirstLineTeamDbContext())
                {
                    Context.Client.Attach(remove);
                    Context.Client.Remove(remove);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async Task<Client> FindbyId(int Id)
        {
            using (Context = new FirstLineTeamDbContext())
            {
                var result = await Context.Client.Where(x => x.IdClient == Id).FirstOrDefaultAsync();
                return result;
            }
        }
        public async Task<IEnumerable<Client>> GetClients()
        {
            using (Context = new FirstLineTeamDbContext())
            {
                var result = await Context.Client.Take(100).ToListAsync();
                return result;
            }
        }
    }
}
