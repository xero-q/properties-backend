using Application.Abstractions.Data;
using MediatR;
using Application.Abstractions.Repositories;
using Application.Contracts.Responses;
using Application.Mappings;
using FluentValidation;
using ValidationException = Application.Exceptions.ValidationException;

namespace Application.Features.Properties.Commands.Delete
{
    public class DeletePropertyCommandHandler(IUnitOfWork unitOfWork, IPropertyRepository propertyRepository) : IRequestHandler<DeletePropertyCommand, bool>
    {
        public async Task<bool> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            var property = await propertyRepository.GetByIdAsync(request.Id, cancellationToken);

            if (property is null)
            {
                return false;
            }

            await propertyRepository.DeleteByIdAsync(request.Id, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}