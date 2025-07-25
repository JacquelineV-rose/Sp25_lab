﻿// <auto-generated />
using System;
using HabitTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HabitTrackerAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250330170855_AddNoteTable")]
    partial class AddNoteTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("HabitTrackerAPI.Models.Habit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Completed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Habits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Completed = false,
                            EndDate = new DateTime(2025, 4, 29, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(2660),
                            Frequency = "Daily",
                            Name = "Drink Water",
                            StartDate = new DateTime(2025, 3, 30, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(2590),
                            UserID = 1
                        },
                        new
                        {
                            Id = 2,
                            Completed = false,
                            EndDate = new DateTime(2025, 4, 29, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(2680),
                            Frequency = "Daily",
                            Name = "Exercise",
                            StartDate = new DateTime(2025, 3, 30, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(2680),
                            UserID = 1
                        },
                        new
                        {
                            Id = 3,
                            Completed = false,
                            EndDate = new DateTime(2025, 4, 29, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(2690),
                            Frequency = "Daily",
                            Name = "Make Bed",
                            StartDate = new DateTime(2025, 3, 30, 13, 8, 55, 396, DateTimeKind.Local).AddTicks(2680),
                            UserID = 1
                        });
                });

            modelBuilder.Entity("HabitTrackerAPI.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("HabitTrackerAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "meghan@example.com",
                            PasswordHash = "",
                            Username = "meghan"
                        },
                        new
                        {
                            Id = 2,
                            Email = "johndoe@example.com",
                            PasswordHash = "",
                            Username = "john_doe"
                        },
                        new
                        {
                            Id = 3,
                            Email = "janedoe@example.com",
                            PasswordHash = "",
                            Username = "jane_doe"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
