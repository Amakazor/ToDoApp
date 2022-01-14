using Common.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Common.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskStatus> TaskStatus { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tasklist> Tasklists { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
               

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ToDoApp;Integrated Security=True;Connect Timeout=30").EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<Tasklist>(u => u.TasklistsOwned).WithOne(tl => tl.Owner).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany<Tasklist>(u => u.TasklistsMembered).WithMany(tl => tl.Members);

            base.OnModelCreating(modelBuilder);


        }
    }
}
