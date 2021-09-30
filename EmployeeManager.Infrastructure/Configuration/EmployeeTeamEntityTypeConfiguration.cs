using EmployeeManager.Database;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManager.Infrastructure.Configuration
{
    public class EmployeeTeamEntityTypeConfiguration: AuditableEntityTypeConfiguration<EmployeeTeam>
    {
        public override void Configure(EntityTypeBuilder<EmployeeTeam> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.EmployeeTeamID);
            builder.HasOne(x => x.Employee).WithMany(X=>X.EmployeeTeams).HasForeignKey(x => x.EmployeeID);
            builder.HasOne(x => x.Team).WithMany().HasForeignKey(x => x.TeamID);
        }
    }
}
