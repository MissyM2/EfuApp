﻿// <auto-generated />
using System;
using EfuApp.Plugins.EfCoreSqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfuApp.Plugins.EfCoreSqlServer.Migrations
{
    [DbContext(typeof(EfuAppContext))]
    partial class EfuAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfuApp.CoreBusiness.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("DaysOfWeek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TermId")
                        .HasColumnType("int");

                    b.Property<string>("Times")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.HasIndex("TermId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseDesc = "A course on English",
                            CourseName = "English 101",
                            DaysOfWeek = "",
                            Instructor = "",
                            TermId = 1,
                            Times = ""
                        },
                        new
                        {
                            CourseId = 2,
                            CourseDesc = "A course on Math",
                            CourseName = "Math 101",
                            DaysOfWeek = "",
                            Instructor = "",
                            TermId = 1,
                            Times = ""
                        },
                        new
                        {
                            CourseId = 3,
                            CourseDesc = "A course on Psychology",
                            CourseName = "Psych 101",
                            DaysOfWeek = "",
                            Instructor = "",
                            TermId = 1,
                            Times = ""
                        },
                        new
                        {
                            CourseId = 4,
                            CourseDesc = "A course on Sociology",
                            CourseName = "Soc 101",
                            DaysOfWeek = "",
                            Instructor = "",
                            TermId = 1,
                            Times = ""
                        });
                });

            modelBuilder.Entity("EfuApp.CoreBusiness.Deliverable", b =>
                {
                    b.Property<int>("DeliverableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliverableId"));

                    b.Property<DateTime>("AssignmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("DeliverableDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliverableName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DeliverableId");

                    b.HasIndex("CourseId");

                    b.ToTable("Deliverables");

                    b.HasData(
                        new
                        {
                            DeliverableId = 1,
                            AssignmentDate = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = 1,
                            DeliverableDesc = "5 paragraphs",
                            DeliverableName = "English Essay",
                            DueDate = new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DeliverableId = 2,
                            AssignmentDate = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = 4,
                            DeliverableDesc = "5 paragraphs",
                            DeliverableName = "Sociology Term Paper",
                            DueDate = new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DeliverableId = 3,
                            AssignmentDate = new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = 3,
                            DeliverableDesc = "5 pages; topic of your choice",
                            DeliverableName = "Psychology Study",
                            DueDate = new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DeliverableId = 4,
                            AssignmentDate = new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseId = 2,
                            DeliverableDesc = "2 worksheets",
                            DeliverableName = "Math Homework",
                            DueDate = new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EfuApp.CoreBusiness.Suggestion", b =>
                {
                    b.Property<int>("SuggestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuggestionId"));

                    b.Property<string>("SuggestionDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuggestionName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("SuggestionId");

                    b.ToTable("Suggestions");

                    b.HasData(
                        new
                        {
                            SuggestionId = 1,
                            SuggestionDesc = "Read a book.",
                            SuggestionName = "Suggestion1"
                        },
                        new
                        {
                            SuggestionId = 2,
                            SuggestionDesc = "Make a list.",
                            SuggestionName = "Suggestion2"
                        },
                        new
                        {
                            SuggestionId = 3,
                            SuggestionDesc = "Take notes.",
                            SuggestionName = "Suggestion3"
                        },
                        new
                        {
                            SuggestionId = 4,
                            SuggestionDesc = "Start early.",
                            SuggestionName = "Suggestion4"
                        });
                });

            modelBuilder.Entity("EfuApp.CoreBusiness.Term", b =>
                {
                    b.Property<int>("TermId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TermId"));

                    b.Property<string>("TermDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TermName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("TermWeekCount")
                        .HasColumnType("int");

                    b.HasKey("TermId");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("EfuApp.CoreBusiness.WeekAssessment", b =>
                {
                    b.Property<int>("WeekAssessmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeekAssessmentId"));

                    b.Property<string>("LeastDifficult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LikedLeast")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LikedMost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MostDifficult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TermId")
                        .HasColumnType("int");

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.HasKey("WeekAssessmentId");

                    b.HasIndex("TermId");

                    b.ToTable("WeekAssessments");
                });

            modelBuilder.Entity("EfuApp.CoreBusiness.Course", b =>
                {
                    b.HasOne("EfuApp.CoreBusiness.Term", "Term")
                        .WithMany("Courses")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Term");
                });

            modelBuilder.Entity("EfuApp.CoreBusiness.Deliverable", b =>
                {
                    b.HasOne("EfuApp.CoreBusiness.Course", "Course")
                        .WithMany("Deliverables")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EfuApp.CoreBusiness.WeekAssessment", b =>
                {
                    b.HasOne("EfuApp.CoreBusiness.Term", "Term")
                        .WithMany("WeekAssessments")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Term");
                });

            modelBuilder.Entity("EfuApp.CoreBusiness.Course", b =>
                {
                    b.Navigation("Deliverables");
                });

            modelBuilder.Entity("EfuApp.CoreBusiness.Term", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("WeekAssessments");
                });
#pragma warning restore 612, 618
        }
    }
}
