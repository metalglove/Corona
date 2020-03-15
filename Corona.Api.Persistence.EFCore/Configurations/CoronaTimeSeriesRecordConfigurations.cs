using Corona.Api.Domain;
using Glovali.Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corona.Persistence.EFCore.Configurations
{
    /// <summary>
    /// Represents the <see cref="CoronaTimeSeriesRecordConfigurations"/> class used to configure the relations and columns in the <see cref="DbSet{TEntity}"/> for <see cref="CoronaTimeSeriesRecord"/> in the DbContext.
    /// </summary>
    public class CoronaTimeSeriesRecordConfigurations : IEntityTypeConfiguration<CoronaTimeSeriesRecord>
    {
        /// <inheritdoc cref="IEntityTypeConfiguration{TEntity}.Configure"/>
        public void Configure(EntityTypeBuilder<CoronaTimeSeriesRecord> builder)
        {
            builder.HasKey(p => new { p.Region, p.TimeStamp });
            builder.Ignore(p => ((IEntity<string>)p).Id);
        }
    }
}
