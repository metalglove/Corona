using Corona.Api.Application.Helpers;
using Corona.Persistence.EFCore.Contexts;
using Glovali.Common.Application.Configurations;
using Glovali.Common.Persistence.EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Corona.Api.Persistence.EFCore.Factories
{
    /// <summary>
    /// Represents the <see cref="CoronaDbContextFactory"/> class.
    /// </summary>
    public class CoronaDbContextFactory : DatabaseFactory<CoronaDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoronaDbContextFactory"/> class.
        /// </summary>
        public CoronaDbContextFactory() : base(null, null, false)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoronaDbContextFactory"/> class.
        /// </summary>
        /// <param name="dbConfigurationOptions">The options.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public CoronaDbContextFactory(IOptions<DbConfiguration> dbConfigurationOptions, ILoggerFactory loggerFactory) : base(dbConfigurationOptions, loggerFactory, enableSensitiveLogging: false)
        {

        }

        /// <summary>
        /// Creates a new instance of the <see cref="CoronaDbContext"/> class.
        /// </summary>
        /// <param name="dbContextOptions">The options.</param>
        /// <returns>The user database context.</returns>
        protected override CoronaDbContext CreateNewInstance(DbContextOptions<CoronaDbContext> dbContextOptions)
        {
            return new CoronaDbContext(dbContextOptions);
        }

        protected override DbConfiguration GetDbConfiguration()
        {
            DbConfiguration dbConfiguration = new DbConfiguration();
            ConfigurationLoader.GetConfiguration("appSettings").GetSection("Database").Bind(dbConfiguration);
            return dbConfiguration;
        }
    }
}
