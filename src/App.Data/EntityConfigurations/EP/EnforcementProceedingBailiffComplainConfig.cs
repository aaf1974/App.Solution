using App.Domain.Entity.EP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.EP
{
    class EnforcementProceedingBailiffComplainConfig : IEntityTypeConfiguration<EnforcementProceedingBailiffComplain>
    {
        public void Configure(EntityTypeBuilder<EnforcementProceedingBailiffComplain> builder)
        {
            builder.ToTable("EnforcementProceedingBailiffComplains");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.EnforcementProceeding)
                .WithMany(e => e.EnforcementProceedingBailiffComplains)
                .HasForeignKey(e => e.EnforcementProceedingId)
                .IsRequired();

            builder.Property(e => e.Executive)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.TextComplain)
                .HasMaxLength(500)
                .IsRequired();
        }

    }
}
