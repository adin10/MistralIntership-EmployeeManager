using EmployeeManager.Database;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManager.Infrastructure.Configuration
{
    public class TeamEntityTypeConfiguration : AuditableEntityTypeConfiguration<Team>
    {
        public override void Configure(EntityTypeBuilder<Team> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.TeamID);
            builder.Property(x => x.TeamName).IsRequired();
        }
    }
}
