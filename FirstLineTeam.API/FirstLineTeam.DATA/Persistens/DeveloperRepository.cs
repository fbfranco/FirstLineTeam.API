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
    public class DeveloperRepository : IDeveloperRepository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();

        public async void Create(Developer Developer)
        {
            try
            {
                using (Context)
                {
                    Context.Developer.Add(Developer);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async void Update(Developer Developer)
        {
            try
            {
                using (Context)
                {
                    var update = FindbyId(Developer.IdDeveloper);
                    update.Names = Developer.Names;
                    update.LastName = Developer.LastName;
                    update.Telephone = Developer.Telephone;
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
                    Context.Developer.Remove(remove);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public Developer FindbyId(int Id)
        {
            using (Context)
            {
                var result = Context.Developer.Where(x => x.IdDeveloper == Id).FirstOrDefault();
                return result;
            }
        }
        public async Task<IEnumerable<Developer>> GetDevelopers()
        {
            using (Context)
            {
                var result = await Context.Developer.Take(100).ToListAsync();
                return result;
            }
        }
    }
}
