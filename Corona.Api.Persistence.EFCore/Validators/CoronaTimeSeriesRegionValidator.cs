using Corona.Api.Domain;
using Glovali.Common.Persistence.Exceptions;
using Glovali.Common.Persistence.Interfaces;

namespace Corona.Persistence.EFCore.Validators
{
    /// <summary>
    /// Represents the <see cref="CoronaTimeSeriesRegionValidator"/> class.
    /// </summary>
    public class CoronaTimeSeriesRegionValidator : IEntityValidator<CoronaTimeSeriesRegion>
    {
        /// <inheritdoc cref="IEntityValidator{T}.Validate(T)"/>
        public bool Validate(CoronaTimeSeriesRegion entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Region))
                throw new EntityValidationException($"The {nameof(entity.Region)} cannot be null, empty or consist of a whitespace.");
            if (entity.Records == null)
                throw new EntityValidationException($"{nameof(entity.Records)} cannot be null.");
            if (string.IsNullOrWhiteSpace(entity.Longitude))
                throw new EntityValidationException($"{nameof(entity.Longitude)} cannot be null, empty or consist of a whitespace.");
            if (string.IsNullOrWhiteSpace(entity.Latitude))
                throw new EntityValidationException($"{nameof(entity.Latitude)} cannot be null, empty or consist of a whitespace.");

            return true;
        }
    }
}
