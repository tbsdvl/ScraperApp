using Microsoft.EntityFrameworkCore;

namespace ScraperApp.Infrastructure.Data
{
    /// <summary>
    /// Represents the scraper db context.
    /// </summary>
    public class ScraperDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScraperDbContext"/> class.
        /// </summary>
        /// <param name="dbOptions">The database context options.</param>
        public ScraperDbContext(DbContextOptions<ScraperDbContext> dbOptions)
            : base(dbOptions)
        {
        }

        /// <summary>
        /// Configures the schema for the context.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // configure entities here
        }
    }
}
