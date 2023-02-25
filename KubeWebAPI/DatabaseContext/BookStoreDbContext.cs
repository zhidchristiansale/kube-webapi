using KubeWebAPI.Model;
using KubeWebAPI.ModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace KubeWebAPI.DatabaseContext
{
    public class BookStoreDbContext : DbContext
    {
        #region Constructor

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Properties

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new PriceOfferConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
        }

        #endregion
    }
}
