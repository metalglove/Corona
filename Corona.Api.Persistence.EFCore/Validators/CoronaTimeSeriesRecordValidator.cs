using Corona.Api.Domain;
using Glovali.Common.Persistence.Exceptions;
using Glovali.Common.Persistence.Interfaces;

namespace Corona.Persistence.EFCore.Validators
{
    /// <summary>
    /// Represents the <see cref="CoronaTimeSeriesRecordValidator"/> class.
    /// </summary>
    public class CoronaTimeSeriesRecordValidator : IEntityValidator<CoronaTimeSeriesRecord, string>
    {
        /// <inheritdoc cref="IEntityValidator{T}.Validate(T)"/>
        public bool Validate(CoronaTimeSeriesRecord entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Region))
                throw new EntityValidationException($"The {nameof(entity.Region)} cannot be null, empty or consist of a whitespace.");
            if (entity.Confirmed < 0)
                throw new EntityValidationException($"{nameof(entity.Confirmed)} cannot be negative.");
            if (entity.Deaths < 0)
                throw new EntityValidationException($"{nameof(entity.Deaths)} cannot be negative.");
            if (entity.Recoverd < 0)
                throw new EntityValidationException($"{nameof(entity.Recoverd)} cannot be negative.");

            return true;
        }
    }
}
