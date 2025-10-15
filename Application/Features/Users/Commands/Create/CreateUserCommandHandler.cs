using MediatR;
using Application.Abstractions.Services;
using Application.Exceptions;
using Application.Features.Properties.Commands.Create;
using Domain.Users;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommandHandler(IUserService userService) : IRequestHandler<CreateUserCommand, bool>
    {
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            bool userExists = await userService.UsernameExistsAsync(request.Username, cancellationToken);

            if (userExists)
            {
                throw new ValidationException("There is already a user with that username");
            }
            
            var user = new User
            {
                Username = request.Username,
                Password = request.Password
            };
            
            return await userService.CreateAsync(user, cancellationToken);
        }
    }
}