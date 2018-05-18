using FirstLineTeam.CORE.Interfaces;
using FirstLineTeam.CORE.Models;
using FirstLineTeam.DATA.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace FirstLineTeam.DATA.Persistens
{
    public class ProjectRepository : IProjectRepository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();

        public async void Create(Project Project)
        {
            try
            {
                    Context.Project.Add(Project);
                    await Context.SaveChangesAsync();
                    Context.Dispose();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async void Update(Project Project)
        {
            try
            {
                    var update = FindbyId(Project.IdProject);
                    update.NameProject = Project.NameProject;
                    update.IdClient = Project.IdClient;
                    update.IdDeveloper = Project.IdDeveloper;

                    await Context.SaveChangesAsync();
                    Context.Dispose();
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
                var remove = FindbyId(id);
                Context.Project.Remove(remove);
                await Context.SaveChangesAsync();
                Context.Dispose();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async Task<Project> FindbyId(int Id)
        {
            var result = await Context.Project.Where(x => x.IdProject == Id).FirstOrDefaultAsync();
            Context.Dispose();
            return result;
        }
        public async Task<IEnumerable<Project>> GetProjects()
        {
            using (Context)
            {
                var result = await Context.Project.Take(100).ToListAsync();
                return result;
            }
        }
    }
}
