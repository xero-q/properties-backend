using Application.Contracts.Responses;
using FluentValidation;

namespace Web.Api.Middlewares;
public class ValidationMappingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;
            var validationFailureResponse = new ValidationFailureResponse
            {
                Errors = ex.Errors.Select(x => new ValidationResponse
                {
                    Field = x.PropertyName,
                    Message = x.ErrorMessage
                })
            };

            await context.Response.WriteAsJsonAsync(validationFailureResponse);
        }
        catch (Application.Exceptions.ValidationException ex)
        {
            context.Response.StatusCode = 400;

            var message = new
            {
                Success = false,
                Message = ex.Message
            };

            await context.Response.WriteAsJsonAsync(message);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            var message = new
            {
                Success = false,
                Message = ex.Message
            };
            await context.Response.WriteAsJsonAsync(message);
        }
     
    }
}
