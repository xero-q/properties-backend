using SharedKernel;

namespace Domain.Users;

public class User:Entity
{
    public string Username { get; set; }
    public string Password { get; set; }
}