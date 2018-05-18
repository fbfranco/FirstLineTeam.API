using FirstLineTeam.CORE.Interfaces;
using FirstLineTeam.CORE.Models;
using FirstLineTeam.DATA.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLineTeam.DATA.Persistens
{
    public class DeveloperRepository : IDeveloperRepository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();

        public void Create(Developer Developer)
        {
            try
            {
                using (Context = new FirstLineTeamDbContext())
                {
                    Context.Developer.Add(Developer);
                    Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public void Update(Developer Developer)
        {
            try
            {
                using (Context = new FirstLineTeamDbContext())
                {
                    var update = FindbyId(Developer.IdDeveloper);
                    update.Names = Developer.Names;
                    update.LastName = Developer.LastName;
                    update.Telephone = Developer.Telephone;
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
                    Context.Developer.Remove(remove);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public Developer FindbyId(int Id)
        {
            var result = Context.Developer.Where(x => x.IdDeveloper == Id).FirstOrDefault();
            return result;
        }
        public IEnumerable<Developer> GetDevelopers()
        {
            var result = Context.Developer.Take(100).ToList();
            return result;
        }
    }
}
