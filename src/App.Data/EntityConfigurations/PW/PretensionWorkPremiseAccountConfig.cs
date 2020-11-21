using App.Domain.Entity.PW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.PW
{
    class PretensionWorkPremiseAccountConfig : IEntityTypeConfiguration<PretensionWorkPremiseAccount>
    {
        public void Configure(EntityTypeBuilder<PretensionWorkPremiseAccount> builder)
        {
            builder.ToTable("PretensionWorkPremiseAccounts");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.PretensionWork)
                .WithMany(e => e.PretensionWorkPremiseAccounts)
                .HasForeignKey(e => e.PretensionWorkId)
                .IsRequired();
        }

    }
}
