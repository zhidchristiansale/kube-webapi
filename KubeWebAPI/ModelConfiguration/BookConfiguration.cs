using KubeWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KubeWebAPI.ModelConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .Property(p => p.Price)
                .HasDefaultValue(0)
                .HasColumnType("decimal(9, 2)");

            builder
                .HasOne(p => p.PriceOffer)
                .WithOne()
                .HasForeignKey<PriceOffer>(p => p.BookId);

            builder
                .HasMany(p => p.Reviews)
                .WithOne(p => p.Book)
                .HasForeignKey(p => p.BookId);

            builder
                .HasMany(p => p.BookAuthors)
                .WithOne(p => p.Book)
                .HasForeignKey(p => p.BookId);

            builder
                .HasQueryFilter(p => !p.SoftDeleted);
        }
    }
}
