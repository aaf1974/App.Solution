using App.Domain.Entity.PW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.EntityConfigurations.PW
{
    class PretensionWorkConfig : IEntityTypeConfiguration<PretensionWork>
    {
        public void Configure(EntityTypeBuilder<PretensionWork> builder)
        {
            builder.ToTable("PretensionWorks");

            builder.HasKey(e => e.Id);

        }
    }
}
