using App.Domain.Entity.EP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.EP
{
    class EnforcementProceedingEventConfig : IEntityTypeConfiguration<EnforcementProceedingEvent>
    {
        public void Configure(EntityTypeBuilder<EnforcementProceedingEvent> builder)
        {
            builder.ToTable("EnforcementProceedingEvents");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.EnforcementProceeding)
                .WithMany(e => e.EnforcementProceedingEvents)
                .HasForeignKey(e => e.EnforcementProceedingId)
                .IsRequired();
        }
    }
}
