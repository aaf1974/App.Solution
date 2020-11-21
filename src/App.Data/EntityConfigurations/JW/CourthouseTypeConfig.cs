using App.Domain.Entity.JW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.JW
{
    class CourthouseTypeConfig : IEntityTypeConfiguration<CourthouseType>
    {
        public void Configure(EntityTypeBuilder<CourthouseType> builder)
        {
            builder.ToTable("CourthouseTypes");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title).HasMaxLength(255);

            builder.Property(e => e.Code).HasMaxLength(8);
        }
    }
}
