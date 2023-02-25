using KubeWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KubeWebAPI.ModelConfiguration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasMany(p => p.BookAuthors)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId);
        }
    }
}
