﻿using FirstLineTeam.CORE.Interfaces;
using FirstLineTeam.CORE.Models;
using FirstLineTeam.DATA.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FirstLineTeam.DATA.Persistens
{
    public class FeedbackRepository : IFeedbackRepository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();

        public async void Create(Feedback Feedback)
        {
            try
            {
                using (Context)
                {
                    Context.Feedback.Add(Feedback);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public async void Update(Feedback Feedback)
        {
            try
            {
                using (Context)
                {
                    var update = FindbyId(Feedback.IdFeedback);
                    update.Comment = Feedback.Comment;
                    update.DateRequest = Feedback.DateRequest;;
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
                    Context.Feedback.Remove(remove);
                    await Context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public Feedback FindbyId(int Id)
        {
            using (Context)
            {
                var result = Context.Feedback.Where(x => x.IdFeedback == Id).FirstOrDefault();
                return result;
            }
        }
        public async Task<IEnumerable<Feedback>> GetFeedbacks()
        {
            var result = await Context.Feedback.Take(100).ToListAsync();
            return result;
        }
    }
}
