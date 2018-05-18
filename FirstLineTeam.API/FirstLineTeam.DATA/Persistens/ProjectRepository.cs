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
    public class ProjectRepository : IProjectRepository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();

        public async Task Create(Project Project)
        {
            try
            {
                using (Context)
                {
                    Context.Project.Add(Project);
                    await Context.SaveChangesAsync();
                }
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
                using (Context)
                {
                    var update = FindbyId(Project.IdProject);
                    update.NameProject = Project.NameProject;
                    update.IdClient = Project.IdClient;
                    update.IdDeveloper = Project.IdDeveloper;

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
                    Context.Project.Remove(remove);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public Project FindbyId(int Id)
        {
            using (Context)
            {
                var result = Context.Project.Where(x => x.IdProject == Id).FirstOrDefault();
                Context.Dispose();
                return result;
            }
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
