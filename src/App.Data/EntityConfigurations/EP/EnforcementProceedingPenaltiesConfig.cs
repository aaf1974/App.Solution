using App.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.EP
{
    class EnforcementProceedingPenaltiesConfig : IEntityTypeConfiguration<EnforcementProceedingPenalties>
    {
        public void Configure(EntityTypeBuilder<EnforcementProceedingPenalties> builder)
        {
            builder.ToTable("EnforcementProceedingPenalties");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.EnforcementProceeding)
                .WithMany(e => e.EnforcementProceedingPenalties)
                .HasForeignKey(e => e.EnforcementProceedingId)
                .IsRequired();
        }
    }
}
