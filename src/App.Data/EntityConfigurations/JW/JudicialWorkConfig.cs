using App.Domain.Entity.JW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.JW
{
    class JudicialWorkConfig : IEntityTypeConfiguration<JudicialWork>
    {
        public void Configure(EntityTypeBuilder<JudicialWork> builder)
        {
            builder.ToTable("JudicialWorks");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Courthouse)
                .WithMany(e => e.JudicalWorks)
                .HasForeignKey(e => e.CourthouseId)
                .IsRequired();

            builder.HasMany(e => e.JudicialWorkPremiseAccounts)
                .WithOne(e => e.JudicialWork)
                .HasForeignKey(e => e.JudicialWorkId)
                .IsRequired();
        }
    }
}
