using FluentValidation;

namespace Application.Features.Properties.Commands.Create
{
    /// <summary>
    /// Create Document Validator
    /// </summary>
    public sealed class CreatePropertyValidator : AbstractValidator<CreatePropertyCommand>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CreatePropertyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required");
            RuleFor(x => x.HostId).NotNull().WithMessage("HostId is required");
            RuleFor(x=>x.PricePerNight).GreaterThan(0).WithMessage("PricePerNight must be greater than 0.01");
        }
    }
}