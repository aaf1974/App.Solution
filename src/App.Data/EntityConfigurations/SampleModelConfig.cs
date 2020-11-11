using App.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations
{
    class SampleModelConfig : IEntityTypeConfiguration<SampleModel>
    {
        public void Configure(EntityTypeBuilder<SampleModel> builder)
        {
            builder.ToTable("SampleModel");

            builder.HasKey(e => e.Id);
        }
    }
}
