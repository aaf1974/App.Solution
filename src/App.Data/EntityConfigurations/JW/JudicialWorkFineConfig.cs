using App.Domain.Entity.JW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.JW
{
    class JudicialWorkFineConfig : IEntityTypeConfiguration<JudicialWorkFine>
    {
        public void Configure(EntityTypeBuilder<JudicialWorkFine> builder)
        {
            builder.ToTable("JudicialWorkFines");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.JudicialWorkPremiseAccount)
                .WithMany(e => e.JudicialWorkFines)
                .HasForeignKey(e => e.JudicialWorkPremiseAccountId)
                .IsRequired();
        }
    }
}
