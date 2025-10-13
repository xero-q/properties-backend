using Application.Abstractions.Services;
using Domain.Entities;

namespace Application.AIModelsFactory;

public class DeepSeekFactory:IModelAIFactory
{
    public IModelAI CreateModelAI(Booking booking, IPromptService promptService)
    {
        return new ModelDeepSeekAI(booking);
    }
}