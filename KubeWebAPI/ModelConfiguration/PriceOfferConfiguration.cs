using KubeWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KubeWebAPI.ModelConfiguration
{
    public class PriceOfferConfiguration : IEntityTypeConfiguration<PriceOffer>
    {
        public void Configure(EntityTypeBuilder<PriceOffer> builder)
        {
            builder
                .Property(p => p.MarkdownPrice)
                .HasDefaultValue(0)
                .HasColumnType("decimal(9, 2)");
        }
    }
}
