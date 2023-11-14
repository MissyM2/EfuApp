
using EfuApp.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class EfuAppContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Deliverable> Deliverables { get; set; }
    public DbSet<Term> Terms { get; set; }
    public DbSet<Suggestion> Suggestions {get; set;}
    public DbSet<WeekAssessment> WeekAssessments { get; set; }

    public EfuAppContext(DbContextOptions<EfuAppContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Term>()
            .HasMany(t => t.WeekAssessments)
            .WithOne(e => e.Term)
            .IsRequired();

        modelBuilder.Entity<Term>()
            .HasMany(t => t.Courses)
            .WithOne(e => e.Term)
            .IsRequired();


        modelBuilder.Entity<Deliverable>()
            .HasOne(e => e.Course)
            .WithMany(e => e.Deliverables)
            .HasForeignKey(e => e.CourseId)
            .IsRequired();



        //seeding data

        //modelBuilder.Entity<Term>().HasData(
          // new Term { TermId = 1, TermName = "Wi2023", TermDesc = "Winter, 2023", TermWeekCount = 0 },
            //new Term { TermId = 2, TermName = "Sp2023", TermDesc = "Spring, 2023", TermWeekCount = 12 },
            //new Term { TermId = 3, TermName = "Su2023", TermDesc = "Summer, 2023", TermWeekCount = 9 },
            //new Term { TermId = 4, TermName = "Fa2023", TermDesc = "Fall, 2023", TermWeekCount = 12 }
      // );

        //modelBuilder.Entity<Course>().HasData(
        //    new Course { CourseId = 1, TermId = 1, CourseName = "English 101", CourseDesc = "A course on English"},
        //    new Course { CourseId = 2, TermId= 1,  CourseName = "Math 101", CourseDesc = "A course on Math" },
        //    new Course { CourseId = 3, TermId= 1, CourseName = "Psych 101", CourseDesc = "A course on Psychology"},
        //    new Course { CourseId = 4, TermId = 1, CourseName = "Soc 101", CourseDesc = "A course on Sociology" },
        //    new Course { CourseId = 5, TermId = 1, CourseName = "PE 101", CourseDesc = "A course on Phys Ed" }
        //);

        //modelBuilder.Entity<Deliverable>().HasData(
        //    new Deliverable {
        //        DeliverableId = 1, 
        //        CourseId = 1,
        //        DeliverableName = "English Essay", 
        //        DeliverableDesc = "5 paragraphs",
        //        AssignmentDate = new DateTime(2023, 9, 15), 
        //        DueDate = new DateTime(2023, 10, 15)
        //    },
        //    new Deliverable { 
        //        DeliverableId = 2, 
        //        CourseId = 4,
        //        DeliverableName = "Sociology Term Paper", 
        //        DeliverableDesc = "5 paragraphs", 
        //        AssignmentDate = new DateTime(2023, 9, 1), 
        //        DueDate = new DateTime(2023, 9, 29) 
        //    },
        //    new Deliverable {
        //        DeliverableId = 3, 
        //        CourseId = 3,
        //        DeliverableName = "Psychology Study", 
        //        DeliverableDesc = "5 pages; topic of your choice", 
        //        AssignmentDate = new DateTime(2023, 9, 10), 
        //        DueDate = new DateTime(2023, 9, 20)},
        //    new Deliverable { 
        //        DeliverableId = 4, 
        //        CourseId = 2,
        //        DeliverableName = "Math Homework", 
        //        DeliverableDesc = "2 worksheets", 
        //        AssignmentDate = new DateTime(2023, 9, 20), 
        //        DueDate = new DateTime(2023, 9, 21) 
        //    }

        //);

        //modelBuilder.Entity<Suggestion>().HasData(
        //    new Suggestion { SuggestionId = 1, SuggestionName = "Suggestion1", SuggestionDesc = "Read a book."},
        //    new Suggestion { SuggestionId = 2, SuggestionName = "Suggestion2", SuggestionDesc = "Make a list." },
        //    new Suggestion { SuggestionId = 3, SuggestionName = "Suggestion3", SuggestionDesc = "Take notes."},
        //    new Suggestion { SuggestionId = 4, SuggestionName = "Suggestion4", SuggestionDesc = "Start early." }

        //);

       
    }


}
