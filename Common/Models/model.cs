using Common.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;


namespace Common.Models
{
    public class Db : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskStatus> TaskStatus { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tasklist> Tasklists { get; set; }

        // to test
        
        public string DbPath { get; private set; }

        public Db()
        {
            // do poprawy
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}AppDB.MDF";
        }
        
        
        public Db(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("UserSchema");
            modelBuilder.Entity<User>();
            modelBuilder.Entity<TaskStatus>();
            modelBuilder.Entity<Task>();
            modelBuilder.Entity<Tasklist>().HasMany(c => c.Members).WithOne(p => p.Id).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Tasklist>().HasMany(c => c.Tasks).WithOne(p => p.Id).HasForeignKey(f => f.TaskId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Tasklist>().HasMany(c => c.TaskStatuses).WithOne(p => p.Id).HasForeignKey(f => f.TaskStatusId).OnDelete(DeleteBehavior.Cascade);
        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }
        */
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.

       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            //=> options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
           // => options.UseSqlServer($"Data Source={DbPath}");
            => options.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VSv2\\ToDoApp\\Common\\AppDB.mdf;Integrated Security=True;Connect Timeout=30");
        
        //
    }
    


}
