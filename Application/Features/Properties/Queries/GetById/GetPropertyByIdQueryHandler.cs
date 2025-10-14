using MediatR;
using Application.Abstractions.Repositories;
using Application.Contracts.Responses;
using Application.Exceptions;
using Application.Mappings;

namespace Application.Features.Properties.Queries.GetById
{
    public class GetPropertyByIdQueryHandler(IPropertyRepository propertyRepository) : IRequestHandler<GetPropertyByIdQuery, PropertyResponse>
    {
        public async Task<PropertyResponse> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var property = await propertyRepository.GetByIdAsync(request.Id, cancellationToken);

            if (property is null)
            {
                throw new NotFoundException("Property",request.Id);
            }

            return property.MapToResponse();
        }
    }
}