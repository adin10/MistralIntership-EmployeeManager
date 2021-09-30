using EmployeeManager.Database;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManager.Infrastructure.Configuration
{
    public class TrackingEntityTypeConfiguration:AuditableEntityTypeConfiguration<Tracking>
    {
        public override void Configure(EntityTypeBuilder<Tracking> builder)
        {
            base.Configure(builder);

            builder.HasKey(q => q.TrackingID);

            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.WorkHours).IsRequired();

            builder.HasOne(x => x.ProjectTeam).WithMany().HasForeignKey(x => x.ProjectTeamID);
            builder.HasOne(x => x.EmployeeTeam).WithMany().HasForeignKey(x => x.EmployeeTeamID);
        }

    }
}
