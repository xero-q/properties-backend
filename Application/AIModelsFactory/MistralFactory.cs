using Application.Abstractions.Services;
using Domain.Entities;

namespace Application.AIModelsFactory;

public class MistralFactory:IModelAIFactory
{
    public IModelAI CreateModelAI(Booking booking, IPromptService promptService)
    {
        return new ModelMistralAI(booking, promptService);
    }
}