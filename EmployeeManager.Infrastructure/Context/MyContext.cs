using EmployeeManager.Database;
using EmployeeManager.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Context
{
    public class MyContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Team> Team { get; set; }

        public DbSet<EmployeeTeam> EmployeeTeam { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<ProjectTeam> ProjectTeam { get; set; }

        public DbSet<Tracking> Tracking { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EmployeeEntityTypeConfiguration).Assembly);
            builder.Entity<IdentityUserLogin<int>>().HasKey(x => x.UserId);

            foreach(var model in builder.Model.GetEntityTypes())
            {

                foreach(var fk in model.GetForeignKeys())
                {
                    fk.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }
    }
}