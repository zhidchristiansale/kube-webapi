using KubeWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KubeWebAPI.ModelConfiguration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .Property(p => p.NumStars)
                .HasDefaultValue(1)
                .HasMaxLength(5);

            builder
                .HasQueryFilter(p => !p.SoftDeleted);
        }
    }
}
