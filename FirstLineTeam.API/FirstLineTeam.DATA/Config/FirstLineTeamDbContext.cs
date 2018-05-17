using FirstLineTeam.CORE.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FirstLineTeam.DATA.Config
{
    class FirstLineTeamDbContext : DbContext
    {
        //Config Data Base
        public FirstLineTeamDbContext() :base("DefaultConnection"){}

        //Create Data Model
        public DbSet<Client> Client { get; set; }
        public DbSet<Developer> Developer { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectPhase> ProjectPhase { get; set; }
        public DbSet<CheckListTask> CheckListTask { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Task> Task { get; set; }

        //Modeling tables
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Model Client
            modelBuilder.Entity<Client>().HasKey(x => x.IdClient);
            modelBuilder.Entity<Client>().Property(x => x.Names).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Client>().Property(x => x.LastName).HasMaxLength(60);
            modelBuilder.Entity<Client>().Property(x => x.Telephone).HasMaxLength(20);
            #endregion

            #region Model Developer
            modelBuilder.Entity<Developer>().HasKey(x => x.IdDeveloper);
            modelBuilder.Entity<Developer>().Property(x => x.Names).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Developer>().Property(x => x.LastName).HasMaxLength(60);
            modelBuilder.Entity<Developer>().Property(x => x.Telephone).HasMaxLength(20);
            #endregion

            #region Model Project
            modelBuilder.Entity<Project>().HasKey(x => x.IdProject);
            modelBuilder.Entity<Project>().Property(x => x.IdClient).IsRequired();
            modelBuilder.Entity<Project>().Property(x => x.IdDeveloper).IsRequired();
            modelBuilder.Entity<Project>().Property(x => x.NameProject).HasMaxLength(30).IsRequired();
            #endregion

            #region Model ProjectPhase
            modelBuilder.Entity<ProjectPhase>().HasKey(x => x.IdProjectPhase);
            modelBuilder.Entity<ProjectPhase>().Property(x => x.IdProject).IsRequired();
            modelBuilder.Entity<ProjectPhase>().Property(x => x.IdCheckListTask).IsRequired();
            modelBuilder.Entity<ProjectPhase>().Property(x => x.NamePhase).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<ProjectPhase>().Property(x => x.DescriptionPhase).HasMaxLength(250);
            modelBuilder.Entity<ProjectPhase>().Property(x => x.EstimatedDate).IsRequired();
            #endregion

            #region Model CheckListTask
            modelBuilder.Entity<CheckListTask>().HasKey(x => x.IdCheckListTask);
            modelBuilder.Entity<CheckListTask>().Property(x => x.IdTask).IsRequired();
            #endregion

            #region Model Feedback
            modelBuilder.Entity<Feedback>().HasKey(x => x.IdFeedback);
            modelBuilder.Entity<Feedback>().Property(x => x.IdProject).IsRequired();
            modelBuilder.Entity<Feedback>().Property(x => x.Comment).HasMaxLength(250);
            modelBuilder.Entity<Feedback>().Property(x => x.DateRequest).IsRequired();
            #endregion

            #region Model Taskk
            modelBuilder.Entity<Taskk>().HasKey(x => x.IdTask);
            modelBuilder.Entity<Taskk>().Property(x => x.IdFeedback).IsRequired();
            modelBuilder.Entity<Taskk>().Property(x => x.NameTask).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Taskk>().Property(x => x.DescriptionTask).HasMaxLength(250);
            modelBuilder.Entity<Taskk>().Property(x => x.TaskStart).IsRequired();
            modelBuilder.Entity<Taskk>().Property(x => x.TaskEnd).IsRequired();
            modelBuilder.Entity<Taskk>().Property(x => x.State).IsRequired();
            #endregion
        }
    }
}
