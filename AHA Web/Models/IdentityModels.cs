﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using AHA_web.Models;

namespace AHA_Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //This will create database if one doesn't exist.

            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());

            //This will drop and re-create the database if model changes.

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
             
             base.OnModelCreating(modelBuilder);
         }
         public DbSet<AdelanteStaff> Staff { get; set; }
         public DbSet<BoardMember> BoardMember { get; set; }
         public DbSet<Donor> Donors { get; set; }
         public DbSet<DonorContact> Contact { get; set; }
         public DbSet<Event> Events { get; set; }
         public DbSet<Grant> Grants { get; set; }
         public DbSet<Grantor> Grantors { get; set; }
        public DbSet<Parent> Parents { get; set; }
         public DbSet<Student> Students { get; set; }
         public DbSet<StudentAttendence> StudentAttendence { get; set; }
         public DbSet<StudentFamily> StudentFamily { get; set; }
         public DbSet<Volunteer> Volunteers { get; set; }
           
         public DbSet<VolunteerHistory> VolunteerHistory { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramEnrollment> ProgramEnrollment { get; set; }
}
}