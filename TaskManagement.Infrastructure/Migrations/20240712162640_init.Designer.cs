﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagement.Infrastructure.Data;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    [DbContext(typeof(TaskManagementDbContext))]
    [Migration("20240712162640_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagement.Domain.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.ETask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.ToTable("ETasks");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Document", b =>
                {
                    b.HasOne("TaskManagement.Domain.Entities.ETask", "ETask")
                        .WithMany("Documents")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ETask");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.ETask", b =>
                {
                    b.HasOne("TaskManagement.Domain.Entities.User", "AssignedUser")
                        .WithMany("ETasks")
                        .HasForeignKey("AssignedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedUser");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Note", b =>
                {
                    b.HasOne("TaskManagement.Domain.Entities.ETask", "ETask")
                        .WithMany("Notes")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ETask");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.User", b =>
                {
                    b.HasOne("TaskManagement.Domain.Entities.Team", "Team")
                        .WithMany("Users")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.ETask", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Notes");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Team", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.User", b =>
                {
                    b.Navigation("ETasks");
                });
#pragma warning restore 612, 618
        }
    }
}
