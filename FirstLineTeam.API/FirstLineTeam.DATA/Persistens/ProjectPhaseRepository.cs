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
    public class ProjectPhaseRepository : IProjectPhaseRepository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();

        public async void Create(ProjectPhase ProjectPhase)
        {
            try
            {
                using (Context)
                {
                    Context.ProjectPhase.Add(ProjectPhase);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async void Update(ProjectPhase ProjectPhase)
        {
            try
            {
                using (Context)
                {
                    var update = FindbyId(ProjectPhase.IdProjectPhase);
                    update.NamePhase = ProjectPhase.NamePhase;
                    update.DescriptionPhase = ProjectPhase.DescriptionPhase;
                    update.EstimatedDate = ProjectPhase.EstimatedDate;
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
                    Context.ProjectPhase.Remove(remove);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public ProjectPhase FindbyId(int Id)
        {
            using (Context)
            {
                var result = Context.ProjectPhase.Where(x => x.IdProjectPhase == Id).FirstOrDefault();
                return result;
            }
        }
        public async Task<IEnumerable<ProjectPhase>> GetProjectPhases()
        {
            using (Context)
            {
                var result = await Context.ProjectPhase.Take(100).ToListAsync();
                return result;
            }
        }
    }
}
