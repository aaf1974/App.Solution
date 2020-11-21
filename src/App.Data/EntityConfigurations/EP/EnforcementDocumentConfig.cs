using App.Domain.Entity.EP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.EP
{
    class EnforcementDocumentConfig : IEntityTypeConfiguration<EnforcementDocument>
    {
        public void Configure(EntityTypeBuilder<EnforcementDocument> builder)
        {
            builder.ToTable("EnforcementDocuments");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ExecutiveDocumentNumber).HasMaxLength(20);

            builder.HasOne(e => e.JudicialWork)
                .WithMany(e => e.EnforcementDocuments)
                .HasForeignKey(e => e.JudicialWorkId)
                .IsRequired();
        }
    }
}
