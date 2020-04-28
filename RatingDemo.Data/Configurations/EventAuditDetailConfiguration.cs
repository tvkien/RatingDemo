using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RatingDemo.Data.Entities;
using RatingDemo.Data.Enums;

namespace RatingDemo.Data.Configurations
{
    public class EventAuditDetailConfiguration : IEntityTypeConfiguration<EventAuditDetail>
    {
        public void Configure(EntityTypeBuilder<EventAuditDetail> builder)
        {
            builder.ToTable("EventAuditDetails");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Passcode).IsRequired();
            builder.Property(x => x.EventType).HasDefaultValue(EventTypes.None);
            builder.Property(x => x.ServiceType).HasDefaultValue(ServiceType.None);
        }
    }
}