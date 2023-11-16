using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EfuApp.WebApp.Data
{
    public class AccountDbContext : IdentityDbContext<ApplicationUser>
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //    modelBuilder.Entity<IdentityRole>().HasData(
            //        new IdentityRole
            //        {
            //            Name = "User",
            //            NormalizedName = "USER",
            //            Id = "8343074e-8623-4e1a-b0c1-84fb8678c8f3"
            //        },
            //        new IdentityRole
            //        {
            //            Name = "Administrator",
            //            NormalizedName = "ADMINISTRATOR",
            //            Id = "c7ac6cfe-1f10-4baf-b604-cde350db9554"
            //        }
            //    );

            //    var hasher = new PasswordHasher<ApplicationUser>();

            //    modelBuilder.Entity<ApplicationUser>().HasData(
            //        new ApplicationUser
            //        {
            //            Id = "8e448afa-f008-446e-a52f-13c449803c2e",
            //            Email = "admin@efuapp.com",
            //            NormalizedEmail = "ADMIN@EFUAPP.COM",
            //            UserName = "admin@efuAPP.com",
            //            NormalizedUserName = "ADMIN@EFUAPP.COM",
            //            FirstName = "System",
            //            LastName = "Admin",
            //            PasswordHash = hasher.HashPassword(null, "P@ssword1")
            //        },
            //        new ApplicationUser
            //        {
            //            Id = "30a24107-d279-4e37-96fd-01af5b38cb27",
            //            Email = "user@efuapp.com",
            //            NormalizedEmail = "USER@EFUAPP.COM",
            //            UserName = "user@efuapp.com",
            //            NormalizedUserName = "USER@EFUAPP.COM",
            //            FirstName = "Genericstudent",
            //            LastName = "User",
            //            PasswordHash = hasher.HashPassword(null, "P@ssword1")
            //        },
            //        new ApplicationUser
            //        {
            //            Id = "40a24107-d279-4e37-96fd-01af5b38cb27",
            //            Email = "stud1@efuapp.com",
            //            NormalizedEmail = "STUD1@EFUAPP.COM",
            //            UserName = "stud1@efuapp.com",
            //            NormalizedUserName = "STUD1@EFUAPP.COM",
            //            FirstName = "Student",
            //            LastName = "One",
            //            PasswordHash = hasher.HashPassword(null, "P@ssword1")
            //        },
            //        new ApplicationUser
            //        {
            //            Id = "50a24107-d279-4e37-96fd-01af5b38cb27",
            //            Email = "stud2@efuapp.com",
            //            NormalizedEmail = "STUD2@EFUAPP.COM",
            //            UserName = "stud2@efuapp.com",
            //            NormalizedUserName = "STUD2@EFUAPP.COM",
            //            FirstName = "Student",
            //            LastName = "Two",
            //            PasswordHash = hasher.HashPassword(null, "P@ssword1")
            //        }
            //    );

            //    modelBuilder.Entity<IdentityRole<string>>().HasData(
            //        new IdentityUserRole<string>
            //        {
            //            RoleId = "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
            //            UserId = "30a24107-d279-4e37-96fd-01af5b38cb27"
            //        },
            //        new IdentityUserRole<string>
            //        {
            //            RoleId = "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
            //            UserId = "40a24107-d279-4e37-96fd-01af5b38cb27"
            //        },
            //        new IdentityUserRole<string>
            //        {
            //            RoleId = "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
            //            UserId = "50a24107-d279-4e37-96fd-01af5b38cb27"
            //        },
            //        new IdentityUserRole<string>
            //        {
            //            RoleId = "c7ac6cfe-1f10-4baf-b604-cde350db9554",
            //            UserId = "8e448afa-f008-446e-a52f-13c449803c2e"
            //        }
            //    );
        }

    }
}
