using App.Domain.Entity.EP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.EP
{
    class EnforcementProceedingReasonEndingConfig : IEntityTypeConfiguration<EnforcementProceedingReasonEnding>
    {
        public void Configure(EntityTypeBuilder<EnforcementProceedingReasonEnding> builder)
        {
            builder.ToTable("EnforcementProceedingReasonEnding");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.NoteNumber).HasMaxLength(20);

            builder.Property(e => e.NoteText).HasMaxLength(255);
        }
    }
}
