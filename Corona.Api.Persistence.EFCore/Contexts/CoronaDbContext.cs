using Glovali.Common.Persistence.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Corona.Persistence.EFCore.Contexts
{
    /// <summary>
    /// Represents the <see cref="CoronaDbContext"/> class.
    /// </summary>
    public class CoronaDbContext : DbContext
    {
        /// <summary>
        /// Initializes an instance of the <see cref="CoronaDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public CoronaDbContext(DbContextOptions<CoronaDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Applies all entity configurations.
        /// </summary>
        /// <param name="modelBuilder">the model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations<CoronaDbContext>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
