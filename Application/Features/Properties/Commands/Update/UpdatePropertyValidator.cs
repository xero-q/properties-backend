using FluentValidation;

namespace Application.Features.Properties.Commands.Update
{
    /// <summary>
    /// Create Document Validator
    /// </summary>
    public sealed class UpdatePropertyValidator : AbstractValidator<UpdatePropertyCommand>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UpdatePropertyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required");
            RuleFor(x => x.HostId).NotNull().WithMessage("HostId is required");
            RuleFor(x=>x.PricePerNight).GreaterThan(0).WithMessage("PricePerNight must be greater than 0");
            RuleFor(x => x.Status).NotNull().WithMessage("Status is required");
        }
    }
}