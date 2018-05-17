using System;
using FirstLineTeam.CORE.Models;
using FirstLineTeam.DATA.Persistens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstLineTeam.TEST.Tests
{
    [TestClass]
    public class FeedbackTest
    {
        FeedbackRepository repo = new FeedbackRepository();
        Feedback Feedback = new Feedback();

        [TestMethod]
        public void InitializeFeeddback()
        {
            //Feedback.IdProject = 1;
            //Feedback.
            //repo.Create(feedback);
        }
    }
}
