using Common.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;


namespace Common.Models
{
    public class Common : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskStatus> TaskStatus { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tasklist> Tasklists { get; set; }

        // to test
        public string DbPath { get; private set; }

        public Common()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}Common.db";
        }
        //
        public Common(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("UserSchema");
            modelBuilder.Entity<User>();
            modelBuilder.Entity<TaskStatus>();
            modelBuilder.Entity<Task>();
            modelBuilder.Entity<Tasklist>().HasMany(c => c.Members).WithOne(p => p.Id).HasForeignKey(f => f.TasklistId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Tasklist>().HasMany(c => c.Tasks).WithOne(p => p.Id).HasForeignKey(f => f.TasklistId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Tasklist>().HasMany(c => c.TaskStatuses).WithOne(p => p.Id).HasForeignKey(f => f.TasklistId).OnDelete(DeleteBehavior.Cascade);
        }

       // protected override void OnConfiguring(DbContextOptionsBuilder options)
      //  {

       // }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.


        // to test 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source={DbPath}");

        //
    }
    


}
