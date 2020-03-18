using Corona.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corona.Persistence.EFCore.Configurations
{
    /// <summary>
    /// Represents the <see cref="ReportConfiguration"/> class used to configure the relations and columns in the <see cref="DbSet{TEntity}"/> for <see cref="Report"/> in the DbContext.
    /// </summary>
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        /// <inheritdoc cref="IEntityTypeConfiguration{TEntity}.Configure"/>
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(p => p.Id);
            builder.OwnsMany<Record>(p => p.Records, p =>
            {
                p.HasKey(pa => pa.Id);
                p.WithOwner();
                p.OwnsMany<Data>(pa => pa.Data, pa =>
                {
                    pa.HasKey(pap => pap.Id);
                    pa.WithOwner();
                });
            });
        }
    }
}
