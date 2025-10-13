using Application.Abstractions.Data;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api;
    
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization();
        services.AddControllers();
        
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("http://localhost:4200") // Replace with your frontend URL
                    .AllowAnyHeader()
                    .AllowAnyMethod(); // Allows POST, GET, OPTIONS, etc.
            });
        });
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy =>
                policy.RequireClaim("Admin","true"));
        });
        
        services.AddApiVersioning(options =>
        {
            // Default API version when not specified
            options.DefaultApiVersion = new ApiVersion(1, 0);

            // Assume default version when version is not specified
            options.AssumeDefaultVersionWhenUnspecified = true;

            // Allow versioning via URL segment (e.g., v1, v2)
            options.ApiVersionReader = new Microsoft.AspNetCore.Mvc.Versioning.UrlSegmentApiVersionReader();

            // Report supported and deprecated API versions in response headers
            options.ReportApiVersions = true;
        });
        
        var applicationAssembly = typeof(IApplicationDbContext).Assembly;
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));

        return services;
    } 
}
