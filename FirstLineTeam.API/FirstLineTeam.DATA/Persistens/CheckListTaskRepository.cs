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
    public class CheckListTaskRepository : ICheckListTaskRespository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();

        public async void Create(CheckListTask CheckListTask)
        {
            try
            {
                using (Context)
                {
                    Context.CheckListTask.Add(CheckListTask);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async void Update(CheckListTask CheckListTask)
        {
            try
            {
                using (Context)
                {
                    var update = FindbyId(CheckListTask.IdCheckListTask);
                    update.IdTask = CheckListTask.IdTask;
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
                    Context.CheckListTask.Remove(remove);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public CheckListTask FindbyId(int Id)
        {
            using (Context)
            {
                var result = Context.CheckListTask.Where(x => x.IdCheckListTask == Id).FirstOrDefault();
                return result;
            }
        }
        public async Task<IEnumerable<CheckListTask>> GetCheckListTasks()
        {
            using (Context)
            {
                var result = await Context.CheckListTask.Take(100).ToListAsync();
                return result;
            }
        }
    }
}
