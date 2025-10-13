using Application.Contracts.Requests;
using Application.Contracts.Responses;
using Domain.Entities;

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
    
    public static ModelTypesResponse MapToResponse(this IEnumerable<ModelType> modelTypes)
    {
        return new ModelTypesResponse
        {
            Items = modelTypes.Select(MapToResponse)
        };
    }
    
    public static DomainEvent MapToUser(this CreateUserRequest request)
    {
        return new DomainEvent
        {
            Username = request.Username,
            Password = request.Password,
            IsAdmin = false
        };
    }
    
    public static UserResponse MapToResponse(this DomainEvent domainEvent)
    {
        return new UserResponse
        {
            Id = domainEvent.Id,
            Username = domainEvent.Username
        };
    }
    
    public static Host MapToModel(this CreateHostRequest request)
    {
        return new Host
        {
            Name = request.Name,
            Identifier = request.Identifier,
            Temperature = request.Temperature,
            ModelTypeId = request.ModelTypeId,
            EnvironmentVariable = request.EnvironmentVariable
        };
    }
    
  
    
    public static ModelsResponse MapToResponse(this IEnumerable<Host> models)
    {
        return new ModelsResponse
        {
            Items = models.Select(MapToResponse)
        };
    }

    public static Booking MapToThread(this CreateThreadRequest request,int modelId, int userId)
    {
        return new Booking
        {
            Title = request.Title,
            ModelId = modelId,
            UserId = userId
        };
    }

    private static ThreadResponse MapToResponse(this Booking booking)
    {
        var createdAtLocal = TimeZoneInfo.ConvertTimeFromUtc(
            booking.CreatedAt,
            TimeZoneInfo.Local
        );

        var createdAtLocalDate = createdAtLocal.ToString("yyyy-MM-dd");
        
        return new ThreadResponse
        {
            Id = booking.Id,
            Title = booking.Title,
            ModelId = booking.ModelId,
            CreatedAt = createdAtLocal,
            CreatedAtDate = createdAtLocalDate,
            ModelName = booking.Host.Name,
            ModelType = booking.Host.Provider.Name,
            ModelIdentifier = booking.Host.Identifier
        };
    }
    
    public static ThreadSimpleResponse MapToSimpleResponse(this Booking booking)
    {
        return new ThreadSimpleResponse
        {
            Id = booking.Id,
            Title = booking.Title,
            ModelId = booking.ModelId,
            CreatedAt = booking.CreatedAt
        };
    }
    
    
    public static PaginatedThreadsResponse MapToResponse(this Dictionary<string, List<Booking>> threads, int currentPage, bool hasNext)
    {
       return new PaginatedThreadsResponse
        {
            CurrentPage = currentPage,
            HasNext = hasNext,
            Results = threads.Select(x=>new ThreadsResponse
            {
                Date = x.Key,
                Threads = x.Value.Select(MapToResponse)
            })
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
    
    public static PromptsResponse MapToResponse(this IEnumerable<Property> prompts)
    {
        return new PromptsResponse
        {
            Items = prompts.Select(MapToResponse)
        };
    }
    
}