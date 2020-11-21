using App.Domain.Entity.JW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.JW
{
    class CourthouseConfig : IEntityTypeConfiguration<Courthouse>
    {
        public void Configure(EntityTypeBuilder<Courthouse> builder)
        {
            builder.ToTable("Courthouses");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.CourthouseType).WithMany(e => e.Courthouses)
                .HasForeignKey(e => e.CourthouseTypeId)
                .IsRequired();

            builder.Property(e => e.ShortName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.PostAdress)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
