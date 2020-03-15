using Corona.Api.Domain.Entities;
using Glovali.Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corona.Persistence.EFCore.Configurations
{
    /// <summary>
    /// Represents the <see cref="CoronaTimeSeriesRegionConfigurations"/> class used to configure the relations and columns in the <see cref="DbSet{TEntity}"/> for <see cref="CoronaTimeSeriesRegion"/> in the DbContext.
    /// </summary>
    public class CoronaTimeSeriesRegionConfigurations : IEntityTypeConfiguration<CoronaTimeSeriesRegion>
    {
        /// <inheritdoc cref="IEntityTypeConfiguration{TEntity}.Configure"/>
        public void Configure(EntityTypeBuilder<CoronaTimeSeriesRegion> builder)
        {
            builder.Ignore(p => ((IEntity<string>)p).Id);
            builder.HasKey(p => p.Region);
            builder
                .HasMany(p => p.Records)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
