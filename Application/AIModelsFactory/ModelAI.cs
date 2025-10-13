using Domain.Entities;

namespace Application.AIModelsFactory;

public abstract class ModelAI(Booking booking):IModelAI
{
    public abstract Task<string?> SendPrompt(string prompt);
  
}