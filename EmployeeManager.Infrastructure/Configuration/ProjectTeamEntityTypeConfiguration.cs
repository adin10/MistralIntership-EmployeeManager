using EmployeeManager.Database;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Configuration
{
   public class ProjectTeamEntityTypeConfiguration:AuditableEntityTypeConfiguration<ProjectTeam>
    {
        public override void Configure(EntityTypeBuilder<ProjectTeam> builder)
        {
            base.Configure(builder);
            builder.HasKey(pt => pt.ProjectTeamID);
            builder.HasOne(pt => pt.Project).WithMany(x => x.ProjectTeams).HasForeignKey(pt => pt.ProjectID);
            builder.HasOne(pt => pt.Team).WithMany().HasForeignKey(pt => pt.TeamID);
        }
    }
}
