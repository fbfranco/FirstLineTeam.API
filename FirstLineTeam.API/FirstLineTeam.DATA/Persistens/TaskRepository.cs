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
    public class TaskRepository : ITaskRepository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();

        public async void Create(Taskk Taskk)
        {
            try
            {
                using (Context)
                {
                    Context.Task.Add(Taskk);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async void Update(Taskk Taskk)
        {
            try
            {
                using (Context)
                {
                    var update = FindbyId(Taskk.IdTask);
                    update.IdFeedback = Taskk.IdFeedback;
                    update.NameTask = Taskk.NameTask;
                    update.DescriptionTask = Taskk.DescriptionTask;
                    update.TaskStart = Taskk.TaskStart;
                    update.TaskEnd = Taskk.TaskEnd;
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
                    Context.Task.Remove(remove);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public Taskk FindbyId(int Id)
        {
            using (Context)
            {
                var result = Context.Task.Where(x => x.IdTask == Id).FirstOrDefault();
                return result;
            }
        }
        public async Task<IEnumerable<Taskk>> GetTasks()
        {
            using (Context)
            {
                var result = await Context.Task.Take(100).ToListAsync();
                return result;
            }
        }
    }
}
