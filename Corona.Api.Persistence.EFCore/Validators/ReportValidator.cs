using Corona.Api.Domain.Entities;
using Glovali.Common.Persistence.Exceptions;
using Glovali.Common.Persistence.Interfaces;

namespace Corona.Persistence.EFCore.Validators
{
    /// <summary>
    /// Represents the <see cref="ReportValidator"/> class.
    /// </summary>
    public class ReportValidator : IEntityValidator<Report, string>
    {
        /// <inheritdoc cref="IEntityValidator{T}.Validate(T)"/>
        public bool Validate(Report entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
                throw new EntityValidationException($"The {nameof(entity.Id)} cannot be null, empty or consist of a whitespace.");
            if (entity.Records?.Count < 0)
                throw new EntityValidationException($"{nameof(entity.Records)} cannot be null or empty.");
            return true;
        }
    }
}
