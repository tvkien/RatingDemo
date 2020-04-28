using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RatingDemo.Data.Entities;
using RatingDemo.Data.Enums;

namespace RatingDemo.Data.Configurations
{
    class RatingInformationConfiguration : IEntityTypeConfiguration<RatingInformation>
    {
        public void Configure(EntityTypeBuilder<RatingInformation> builder)
        {
            builder.ToTable("RatingInformations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.QuestionId).HasDefaultValue(0);
            builder.Property(x => x.ServiceType).HasDefaultValue(ServiceType.None);
            builder.Property(x => x.Scored).HasDefaultValue(0);
        }
    }
}