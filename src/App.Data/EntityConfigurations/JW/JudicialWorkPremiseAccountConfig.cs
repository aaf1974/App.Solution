using App.Domain.Entity.JW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.JW
{
    class JudicialWorkPremiseAccountConfig : IEntityTypeConfiguration<JudicialWorkPremiseAccount>
    {
        public void Configure(EntityTypeBuilder<JudicialWorkPremiseAccount> builder)
        {
            builder.ToTable("JudicialWorkPremiseAccounts");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.JudicialWork)
                .WithMany(e => e.JudicialWorkPremiseAccounts)
                .HasForeignKey(e => e.JudicialWorkId)
                .IsRequired();

        }
    }
}
