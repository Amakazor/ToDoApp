﻿using Common.Models;
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
               
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            //=> options.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ToDoApp", "AppDB.mdf")};Integrated Security=True;Connect Timeout=30");
            => options.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ToDoApp;Integrated Security=True;Connect Timeout=30");
    }
    


}
