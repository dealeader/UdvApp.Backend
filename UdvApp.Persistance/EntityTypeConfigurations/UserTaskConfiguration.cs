using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdvApp.Domain;

namespace UdvApp.Persistence.EntityTypeConfigurations
{
    public class UserTaskConfiguration : IEntityTypeConfiguration<UserTask>
    {
        public void Configure(EntityTypeBuilder<UserTask> builder)
        {
            builder.HasKey(usertask => usertask.Id);
            builder.HasIndex(usertask => usertask.Id).IsUnique();
        }
    }
}
