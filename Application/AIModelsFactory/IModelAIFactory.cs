using Application.Abstractions.Services;
using Domain.Entities;

namespace Application.AIModelsFactory;

public interface IModelAIFactory
{
    public IModelAI CreateModelAI(Booking booking, IPromptService promptService);
}