using FluentValidation;

namespace Application.Features.Properties.Commands.Create
{
    public sealed class CreateDomainEventValidator : AbstractValidator<CreateDomainEventCommand>
    {
        public CreateDomainEventValidator()
        {
            RuleFor(x => x.EventType).NotEmpty().WithMessage("EventType is required");
            RuleFor(x => x.PayloadJSON).NotEmpty().WithMessage("Payload is required");
            RuleFor(x => x.PropertyId).NotNull().WithMessage("PropertyId is required");
   }
    }
}