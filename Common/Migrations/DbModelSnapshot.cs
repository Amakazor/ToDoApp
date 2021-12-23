﻿using System;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Common.Migrations
{
    [DbContext(typeof(Db))]
    partial class DbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Common.Models.Task", b =>
                {
                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("StatusTaskStatusId")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("StatusTaskStatusId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Common.Models.Tasklist", b =>
                {
                    b.Property<int>("id_TaskList_number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_TaskList_number"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("id_TaskList_number");

                    b.ToTable("TaskList");
                });

            modelBuilder.Entity("Common.Models.TaskStatus", b =>
                {
                    b.Property<int?>("TaskStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("TaskStatusId");

                    b.ToTable("TaskStatus");
                });

            modelBuilder.Entity("Common.Models.User", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Common.Models.Task", b =>
                {
                    b.HasOne("Common.Models.TaskStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusTaskStatusId");

                    b.HasOne("Common.Models.Tasklist", "Id")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Id");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Common.Models.TaskStatus", b =>
                {
                    b.HasOne("Common.Models.Tasklist", "Id")
                        .WithMany("TaskStatuses")
                        .HasForeignKey("TaskStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Id");
                });

            modelBuilder.Entity("Common.Models.User", b =>
                {
                    b.HasOne("Common.Models.Tasklist", "Id")
                        .WithMany("Members")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Id");
                });

            modelBuilder.Entity("Common.Models.Tasklist", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("TaskStatuses");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
