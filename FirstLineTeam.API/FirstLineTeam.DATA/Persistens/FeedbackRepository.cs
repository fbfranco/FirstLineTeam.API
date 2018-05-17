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
    public class FeedbackRepository : IFeedbackRepository
    {
        FirstLineTeamDbContext Context = new FirstLineTeamDbContext();

        public void Create(Feedback Feedback)
        {
            try
            {
                using (Context = new FirstLineTeamDbContext())
                {
                    Context.Feedback.Add(Feedback);
                    Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public void Update(Feedback Feedback)
        {
            try
            {
                using (Context = new FirstLineTeamDbContext())
                {
                    var update = FindbyId(Feedback.IdFeedback);
                    update.Comment = Feedback.Comment;
                    update.DateRequest = Feedback.DateRequest;;
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
                    Context.Feedback.Remove(remove);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public Feedback FindbyId(int Id)
        {
            var result = Context.Feedback.Where(x => x.IdFeedback == Id).FirstOrDefault();
            return result;
        }
        public IEnumerable<Feedback> GetFeedbacks()
        {
            var result = Context.Feedback.Take(100).ToList();
            return result;
        }
    }
}
