using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Database.Persistence;

namespace Infrastructure.Repositories;

public class ModelTypeRepository(ApplicationDbContext context) : GenericRepositoryAsync<ModelType>(context), IModelTypeRepository
{
   
}