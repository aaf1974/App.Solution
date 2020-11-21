using App.Domain.Entity.EP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.EP
{
    class BailiffServiceConfig : IEntityTypeConfiguration<BailiffService>
    {
        public void Configure(EntityTypeBuilder<BailiffService> builder)
        {
            builder.ToTable("BailiffServices");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ShortName).HasMaxLength(255);

            builder.Property(e => e.Adress).HasMaxLength(255);
        }
    }
}
