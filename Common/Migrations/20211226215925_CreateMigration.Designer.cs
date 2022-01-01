﻿// <auto-generated />
using System;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Common.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20211226215925_CreateMigration")]
    partial class CreateMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("AuthorUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("Guid")
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("StatusTaskStatusId")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("AuthorUserId");

                    b.HasIndex("StatusTaskStatusId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Common.Models.Tasklist", b =>
                {
                    b.Property<int>("Id_TaskList_number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_TaskList_number"), 1L, 1);

                    b.Property<Guid>("Guid")
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("OwnerUserId")
                        .HasColumnType("int");

                    b.HasKey("Id_TaskList_number");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("TaskList");
                });

            modelBuilder.Entity("Common.Models.TaskStatus", b =>
                {
                    b.Property<int?>("TaskStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid>("Guid")
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

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
                    b.HasOne("Common.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorUserId");

                    b.HasOne("Common.Models.TaskStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusTaskStatusId");

                    b.HasOne("Common.Models.Tasklist", "Id")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Id");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Common.Models.Tasklist", b =>
                {
                    b.HasOne("Common.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUserId");

                    b.Navigation("Owner");
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
