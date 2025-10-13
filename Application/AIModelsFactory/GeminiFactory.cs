using Application.Abstractions.Services;
using Domain.Entities;

namespace Application.AIModelsFactory;

public class GeminiFactory:IModelAIFactory
{
    public IModelAI CreateModelAI(Booking booking, IPromptService promptService)
    {
        return new ModelGeminiAI(booking, promptService);
    }
}