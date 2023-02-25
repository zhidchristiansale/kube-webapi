using KubeWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KubeWebAPI.ModelConfiguration
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder
                .HasKey(p => new { p.BookId, p.AuthorId });

            builder
                .HasQueryFilter(p => !p.SoftDeleted);
        }
    }
}
