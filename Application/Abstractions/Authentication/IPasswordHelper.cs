namespace Application.Abstractions.Authentication;

public interface IPasswordHelper
{
    string HashPassword(string password);

    bool VerifyPassword(string password, string passwordHash);
}
