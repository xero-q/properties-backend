namespace Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object id)
        : base($"{name} with Id '{id}' was not found.")
    {
    }
    
    public NotFoundException(string message) : base(message) { }
}
