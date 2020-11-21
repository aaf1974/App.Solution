using App.Domain.Entity.EP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.EP
{
    class EnforcementProceedingConfig : IEntityTypeConfiguration<EnforcementProceeding>
    {
        public void Configure(EntityTypeBuilder<EnforcementProceeding> builder)
        {
            builder.ToTable("EnforcementProceedings");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.EnforcementProceedingNumber).HasMaxLength(20);

            builder.HasOne(e => e.BailiffService)
                .WithMany(e => e.EnforcementProceedings)
                .HasForeignKey(e => e.BailiffServiceId)
                .IsRequired();

            builder.HasOne(e => e.EnforcementProceedingReasonEnding)
                .WithMany(e => e.EnforcementProceedings)
                .HasForeignKey(e => e.EnforcementProceedingReasonEndingId)
                .IsRequired(false);
        }
    }
}
