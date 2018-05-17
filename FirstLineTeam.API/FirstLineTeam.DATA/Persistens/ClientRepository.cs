using FirstLineTeam.CORE.Interfaces;
using FirstLineTeam.CORE.Models;
using FirstLineTeam.DATA.Config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstLineTeam.DATA.Persistens
{
    public class ClientRepository : IClientRepository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();

        public void Create(Client client)
        {
            try
            {
                using (Context = new FirstLineTeamDbContext())
                {
                    Context.Client.Add(client);
                    Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public void Update(Client client)
        {
            try
            {
                using (Context = new FirstLineTeamDbContext())
                {
                    var update = FindbyId(client.IdClient);
                    update.Names = client.Names;
                    update.LastName = client.LastName;
                    update.Telephone = client.Telephone;
                    Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (Context = new FirstLineTeamDbContext())
                {
                    var remove = FindbyId(id);
                    Context.Client.Remove(remove);
                    Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public Client FindbyId(int? Id)
        {
            var result = Context.Client.Where(x => x.IdClient == Id).FirstOrDefault();
            return result;
        }
        public IEnumerable<Client> GetClients()
        {
            var result = Context.Client.Take(100).ToList();
            return result;
        }
    }
}
