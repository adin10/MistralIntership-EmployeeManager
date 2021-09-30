using EmployeeManager.Database;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Configuration
{
   public class ProjectEntityTypeConfiguration:AuditableEntityTypeConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.ProjectID);
            builder.Property(p => p.ProjectName).IsRequired();
        }
    }
}
