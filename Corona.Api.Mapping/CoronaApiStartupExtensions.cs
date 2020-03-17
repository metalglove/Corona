using Corona.Api.Application.Dtos;
using Corona.Api.Application.Services;
using Corona.Api.Domain.Entities;
using Corona.Api.Infrastructure.Services;
using Corona.Api.Persistence.EFCore.Factories;
using Corona.Persistence.EFCore.Contexts;
using Corona.Persistence.EFCore.Validators;
using Glovali.Common.Application.Configurations;
using Glovali.Common.Application.Interfaces;
using Glovali.Common.Mapping;
using Glovali.Common.Persistence.EFCore;
using Glovali.Common.Persistence.EFCore.Repositories;
using Glovali.Common.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Corona.Api.Mapping
{
    /// <summary>
    /// Represents the <see cref="CoronaApiStartupExtensions"/> class.
    /// </summary>
    public static class CoronaApiStartupExtensions
    {
        /// <summary>
        /// Adds and binds configurations into the <see cref="serviceCollection"/>.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Returns the service collection to chain further upon.</returns>
        public static IServiceCollection AddConfigurations(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions();
            serviceCollection.Configure<DbConfiguration>(configuration.GetSection("Database").Bind);
            return serviceCollection;
        }

        /// <summary>
        /// Adds services from the <see cref="Application"/> assembly into the <see cref="serviceCollection"/>.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns>Returns the service collection to chain further upon.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetAssembly(typeof(CoronaApiStartupExtensions)));

            serviceCollection.AddLogging(p => p.AddConsole());

            serviceCollection.AddSingleton<IFactory<CoronaDbContext>, CoronaDbContextFactory>();

            // Instead of using .AddDbContext, .AddTransient is used because, the IFactory<TrainingRoomDbContext>
            // needs to be used for creating an instance of the TrainingRoomDbContext.
            serviceCollection.AddTransient(p => p.GetService<IFactory<CoronaDbContext>>().Create());

            #region Validators
            serviceCollection.AddTransient<IEntityValidator<Report, string>, ReportValidator>();
            #endregion Validators

            #region Repositories
            serviceCollection.AddTransient<IRepository<Report, string>, Repository<Report, CoronaDbContext, string>>();
            #endregion Repositories

            #region Services
            serviceCollection.AddTransient<IService<ReportDto, string>, CoronaReportService>();
            serviceCollection.AddTransient<IJhuCsseService, JhuCsseService>();
            #endregion Services

            serviceCollection.VerifyDatabaseConnection<CoronaDbContext>();

            return serviceCollection;
        }
    }
}
