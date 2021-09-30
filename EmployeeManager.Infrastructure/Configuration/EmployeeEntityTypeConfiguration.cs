using EmployeeManager.Database;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManager.Infrastructure.Configuration
{
    public class EmployeeEntityTypeConfiguration : AuditableEntityTypeConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {


            base.Configure(builder);
            builder.HasKey(x => x.EmployeeID);
            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).IsRequired();
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserID);
        }
    }
}
