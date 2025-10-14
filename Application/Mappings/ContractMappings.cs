using Application.Contracts.Requests;
using Application.Contracts.Responses;
using Application.Features.Properties.Commands.Create;
using Domain.Hosts;
using Domain.Properties;

namespace Application.Mappings;

public static class ContractMappings
{
    public static Host MapToHost(this CreateHostRequest request)
    {
        return new Host
        {
            FullName = request.FullName,
            Email = request.Email,
            Phone = request.Phone
        };
    }
    
    public static Property MapToProperty(this CreatePropertyCommand request)
    {
        return new Property
        {
            HostId = request.HostId,
            Name = request.Name,
            Location = request.Location,
            PricePerNight = request.PricePerNight,
            Status = request.Status
        };
    }
    
    
    
    public static HostResponse MapToResponse(this Host host)
    {
        return new HostResponse
        {
            Id = host.Id,
            FullName = host.FullName,
            Email = host.Email,
            Phone = host.Phone
            
        };
    }
    public static PropertyResponse MapToResponse(this Property property)
    {
        return new PropertyResponse
        {
            Id = property.Id,
            HostId = property.HostId,
            Name = property.Name,
            Location = property.Location,
            PricePerNight = property.PricePerNight,
            Status = property.Status,
          
        };
    }
    
  
    
}