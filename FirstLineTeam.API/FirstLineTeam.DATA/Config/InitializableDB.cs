using FirstLineTeam.CORE.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace FirstLineTeam.DATA.Config
{
    public class InitializableDB : DropCreateDatabaseIfModelChanges<FirstLineTeamDbContext>
    {
        protected override void Seed(FirstLineTeamDbContext context)
        {
            base.Seed(context);

            #region Initialize Table Client
            context.Client.AddOrUpdate(x => x.IdClient, new Client { Names = "Cliente1", LastName = "Apellidos cliente1", Telephone = "70287468" });
            context.Client.AddOrUpdate(x => x.IdClient, new Client { Names = "Cliente2", LastName = "Apellidos cliente2", Telephone = "70287468" });
            #endregion

            #region Initialize Table Developer
            context.Developer.AddOrUpdate(x => x.IdDeveloper, new Developer { Names = "Developer1", LastName = "Apellidos developer1", Telephone = "70287468" });
            context.Developer.AddOrUpdate(x => x.IdDeveloper, new Developer { Names = "Developer2", LastName = "Apellidos developer2", Telephone = "70287468" });
            #endregion

            #region Initialize Table Project
            context.Project.AddOrUpdate(x => x.IdProject, new Project { NameProject = "Project1", IdClient = 1, IdDeveloper = 1 });
            context.Project.AddOrUpdate(x => x.IdProject, new Project { NameProject = "Project2", IdClient = 2, IdDeveloper = 2 });
            #endregion

            //#region Initialize Table Feedback
            //context.Feedback.AddOrUpdate(x => x.IdFeedback, new Feedback { IdProject = 1, DateRequest = new DateTime(2018, 5, 17), Comment = "Comentario Feedback1" });
            //context.Feedback.AddOrUpdate(x => x.IdFeedback, new Feedback { IdProject = 2, DateRequest = new DateTime(2018, 5, 17), Comment = "Comentario Feedback2" });
            //#endregion

            //#region Initialize Table Taskk
            //context.Task.AddOrUpdate(x => x.IdTask, new Taskk { IdFeedback = 1, NameTask = "Task1", DescriptionTask = "Descripcion de tarea1", TaskStart = new DateTime(2018, 5, 17), TaskEnd = new DateTime(2018, 6, 17), State = 0 });
            //context.Task.AddOrUpdate(x => x.IdTask, new Taskk { IdFeedback = 2, NameTask = "Task2", DescriptionTask = "Descripcion de tarea2", TaskStart = new DateTime(2018, 5, 17), TaskEnd = new DateTime(2018, 6, 17), State = 0 });
            //#endregion

            //#region Initialize Table CheckListTask
            //context.CheckListTask.AddOrUpdate(x => x.IdCheckListTask, new CheckListTask { IdTask = 1 });
            //context.CheckListTask.AddOrUpdate(x => x.IdCheckListTask, new CheckListTask { IdTask = 2 });
            //#endregion

            //#region Initialize Table ProjectPhase
            //context.ProjectPhase.AddOrUpdate(x => x.IdProjectPhase, new ProjectPhase { IdProject = 1, IdCheckListTask = 1, NamePhase = "Phase1", DescriptionPhase = "Descripcion de fase1", EstimatedDate = new DateTime(2018, 5, 17) });
            //context.ProjectPhase.AddOrUpdate(x => x.IdProjectPhase, new ProjectPhase { IdProject = 2, IdCheckListTask = 2, NamePhase = "Phase2", DescriptionPhase = "Descripcion de fase2", EstimatedDate = new DateTime(2018, 5, 17) });
            //#endregion
        }
    }
}
