using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Corona.Api.Application.Helpers
{
    /// <summary>
    /// Represents the <see cref="ConfigurationLoader"/> class.
    /// </summary>
    public static class ConfigurationLoader
    {
        private const string AspNetCore_Environment = "ASPNETCORE_ENVIRONMENT";
        private static IConfiguration? _currentConfiguration;

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="configuration">The configuration file name.</param>
        /// <returns>Returns the <see cref="IConfiguration"/>.</returns>
        public static IConfiguration GetConfiguration(string configuration)
        {
            if (_currentConfiguration != null)
                return _currentConfiguration;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string env = Environment.GetEnvironmentVariable(AspNetCore_Environment);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            string basePath = Directory.GetCurrentDirectory();
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"{configuration}.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: false);

            return _currentConfiguration = builder.Build();
        }
    }
}
