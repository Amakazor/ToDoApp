using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Models
{
    [DataContract()]
    [Table("TaskList")]
    public class Tasklist
    {
        public Tasklist()
        {

        }
        public Tasklist(string name, User owner, HashSet<User> members, HashSet<Task> tasks, HashSet<TaskStatus> taskStatuses)
        {
            Name = name;
            Owner = owner;
            Members = members;
            Tasks = tasks;
            TaskStatuses = taskStatuses;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(IsRequired = true)]
        public int? TaskListID { get; set; }

        [MaxLength(64)]
        [Required]
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        public static void CreateDummyDataIfNotExists()
        {
            User user = new User("user", "user");
            user = user.Authenticate();
            
            User admin = new User("admin", "admin");
            admin = admin.Authenticate();

            using DatabaseContext dbContext = new();
            if ((from ts in dbContext.Tasklists where ts.Owner.UserID == user.UserID select ts).FirstOrDefault() == null)
            {
                User dbUser = (from us in dbContext.Users where us.UserID == user.UserID select us).FirstOrDefault();
                User dbAdmin = (from us in dbContext.Users where us.UserID == admin.UserID select us).FirstOrDefault();

                TaskStatus taskStatus1 = new("TaskStatus1", "ff0000");
                TaskStatus taskStatus2 = new("TaskStatus2", "0000ff");

                Task task1 = new("Task1", "Task1Desc", dbUser, taskStatus1);
                Task task2 = new("Task2", "Task2Desc", dbAdmin, taskStatus2);
                Task task3 = new("Task3", "Task3Desc", dbUser, taskStatus1);

                Tasklist tasklist = new("TEST", dbUser, new HashSet<User> { dbUser, dbAdmin }, new HashSet<Task> { task1, task2, task3 }, new HashSet<TaskStatus> { taskStatus1, taskStatus2 });
                dbContext.Tasklists.Add(tasklist);
                dbContext.SaveChanges();
            }
        }

        [Required]
        [DataMember(IsRequired = true)]
        public User Owner { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public HashSet<User> Members { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public HashSet<Task> Tasks { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public HashSet<TaskStatus> TaskStatuses { get; set; }

        public static HashSet<Tasklist> GetAll(User user)
        {
            using DatabaseContext dbContext = new();
            HashSet <Tasklist> tasklists = (from tl in dbContext.Tasklists where tl.Owner.UserID == user.UserID select tl).ToHashSet();

            return tasklists;
        }

        public static string TryAdd(User user, Tasklist tasklist)
        {
            if (tasklist is null) return "Tasklist doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();

            User dbUser = (from us in dbContext.Users where us.UserID == user.UserID select us).FirstOrDefault();
            if (dbTasklist is not null) return "Tasklist already exists";
            if (!tasklist.Owner.Equals(user)) return "User is not the owner";

            tasklist.Owner = dbUser;

            dbContext.Tasklists.Add(tasklist);
            dbContext.SaveChanges();

            return null;
        }

        public static string TryUpdate(User user, Tasklist tasklist)
        {
            if (tasklist is null) return "Tasklist doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";

            dbTasklist.Name = tasklist.Name;

            dbContext.SaveChanges();

            return null;
        }

        public static string TryDelete(User user, Tasklist tasklist)
        {
            if (tasklist is null) return "Tasklist doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";

            foreach (Task task in dbTasklist.Tasks)
            {
                dbContext.Remove(task);
            }

            foreach (TaskStatus taskStatus in dbTasklist.TaskStatuses)
            {
                dbContext.Remove(taskStatus);
            }

            dbContext.Remove(dbTasklist);

            dbContext.SaveChanges();

            return null;
        }

        public static string TryAddMember(User user, Tasklist tasklist, User member)
        {
            if (tasklist is null) return "Tasklist doesn't exists";
            if (member is null) return "Member user doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();
            User dbMember = (from mb in dbContext.Users where mb.Username == member.Username select mb).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if(dbMember is null) return "Member user  doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";
            if (dbTasklist.Members.Contains(member)) return "Tasklist already has this member";

            dbTasklist.Members.Add(member);

            dbContext.SaveChanges();

            return null;
        }

        public static string TryRemoveMember(User user, Tasklist tasklist, User member)
        {
            if (tasklist is null) return "Tasklist doesn't exists";
            if (member is null) return "Member user doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();
            User dbMember = (from mb in dbContext.Users where mb.Username == member.Username select mb).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if (dbMember is null) return "Member user  doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";
            if (!dbTasklist.Members.Contains(member)) return "Tasklist doesn't have this member";
            if (dbTasklist.Owner.Equals(member)) return "You can't remove the owner";

            foreach(Task task in dbTasklist.Tasks.Where(task => task.Author.Equals(member)))
            {
                task.Author = dbTasklist.Owner;
            }

            dbTasklist.Members.Remove(member);

            dbContext.SaveChanges();

            return null;
        }

        public static string TryChangeOwner(User user, Tasklist tasklist, User member)
        {
            if (tasklist is null) return "Tasklist doesn't exists";
            if (member is null) return "Member user doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();
            User dbMember = (from mb in dbContext.Users where mb.Username == member.Username select mb).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if (dbMember is null) return "Member user  doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";
            if (!dbTasklist.Members.Contains(member)) return "Tasklist doesn't have this member";
            if (dbTasklist.Owner.Equals(member)) return "User is already the owner";

            dbTasklist.Owner = member;

            dbContext.SaveChanges();

            return null;
        }

        public static string TryAddTask(User user, Tasklist tasklist, Task task)
        {
            if (tasklist is null) return "Tasklist doesn't exists";
            if (task is null) return "Task doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();
            Task dbTask = (from ts in dbContext.Tasks where ts.TaskId == task.TaskId select ts).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if (task is null) return "Task doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";
            if (dbTask is not null) return "Task already exists";

            dbContext.Tasks.Add(task);
            dbTasklist.Tasks.Add(task);

            dbContext.SaveChanges();

            return null;
        }

        public static string TryRemoveTask(User user, Tasklist tasklist, Task task)
        {
            if (tasklist is null) return "Tasklist doesn't exists";
            if (task is null) return "Task doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();
            Task dbTask = (from ts in dbContext.Tasks where ts.TaskId == task.TaskId select ts).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if (task is null) return "Task doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";
            if (dbTask is null) return "Task doesn't exists";
            if (!dbTasklist.Tasks.Contains(task)) return "Tasklist doesn't contain the task";

            dbContext.Tasks.Remove(task);
            dbTasklist.Tasks.Remove(task);

            dbContext.SaveChanges();

            return null;
        }

        public static string TryUpdateTask(User user, Tasklist tasklist, Task task)
        {
            if (tasklist is null) return "Tasklist doesn't exists";
            if (task is null) return "Task doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();
            Task dbTask = (from ts in dbContext.Tasks where ts.TaskId == task.TaskId select ts).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if (task is null) return "Task doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";
            if (dbTask is null) return "Task doesn't exists";
            if (!dbTasklist.Tasks.Contains(task)) return "Tasklist doesn't contain the task";

            dbTask.Name = task.Name;
            dbTask.Description = task.Description;
            dbTask.Status = task.Status;

            dbContext.SaveChanges();

            return null;
        }

        public static string TryAddTaskstatus(User user, Tasklist tasklist, TaskStatus taskStatus)
        {
            if (tasklist is null) return "Tasklist doesn't exists";
            if (taskStatus is null) return "Task Status doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();
            TaskStatus dbTaskstatus = (from tss in dbContext.TaskStatus where tss.TaskStatusID == taskStatus.TaskStatusID select tss).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if (taskStatus is null) return "Task Status doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";
            if (dbTaskstatus is not null) return "TaskStatus already exists";

            dbContext.TaskStatus.Add(taskStatus);
            dbTasklist.TaskStatuses.Add(taskStatus);

            dbContext.SaveChanges();

            return null;
        }
        
        public static string TryDeleteTaskstatus(User user, Tasklist tasklist, TaskStatus taskStatus)
        {
            if (tasklist is null) return "Tasklist doesn't exists";
            if (taskStatus is null) return "Task Status doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();
            TaskStatus dbTaskstatus = (from tss in dbContext.TaskStatus where tss.TaskStatusID == taskStatus.TaskStatusID select tss).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if (taskStatus is null) return "Task Status doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";
            if (dbTaskstatus is  null) return "TaskStatus doesn't exists";
            if (!dbTasklist.TaskStatuses.Contains(dbTaskstatus)) return "Tasklist doesn't contain the TaskStatus";
            if (dbTasklist.TaskStatuses.Count < 2) return "Can't remove the last TaskStatus";

            foreach (Task task in dbTasklist.Tasks.Where(task => task.Status.Equals(dbTaskstatus)))
            {
                task.Status = dbTasklist.TaskStatuses.Where(status => !status.Equals(dbTaskstatus)).First();
            }

            dbContext.TaskStatus.Remove(dbTaskstatus);
            dbTasklist.TaskStatuses.Remove(dbTaskstatus);

            dbContext.SaveChanges();

            return null;
        }

        public static string TryUpdateTaskstatus(User user, Tasklist tasklist, TaskStatus taskStatus)
        {
            if (tasklist is null) return "Tasklist doesn't exists";
            if (taskStatus is null) return "Task Status doesn't exists";

            using DatabaseContext dbContext = new();

            Tasklist dbTasklist = (from tl in dbContext.Tasklists where tl.TaskListID == tasklist.TaskListID select tl).FirstOrDefault();
            TaskStatus dbTaskstatus = (from tss in dbContext.TaskStatus where tss.TaskStatusID == taskStatus.TaskStatusID select tss).FirstOrDefault();

            if (dbTasklist is null) return "Tasklist doesn't exists";
            if (taskStatus is null) return "Task Status doesn't exists";
            if (!dbTasklist.Owner.Equals(user)) return "User is not the owner";
            if (dbTaskstatus is null) return "TaskStatus doesn't exists";
            if (!dbTasklist.TaskStatuses.Contains(dbTaskstatus)) return "Tasklist doesn't contain the TaskStatus";

            dbTaskstatus.Color = taskStatus.Color;
            dbTaskstatus.Name = taskStatus.Name;

            dbContext.SaveChanges();

            return null;
        }
    }
}
