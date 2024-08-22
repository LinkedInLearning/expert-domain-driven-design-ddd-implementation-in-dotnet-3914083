using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Application;

public class ManagementApplicationService(IBreedService breedService,
                                          ManagementDbContext dbContext)
{
    public async Task Handle(CreatePetCommand command)
    {

        var breedId = new BreedId(command.BreedId, breedService);
        var newPet = new Pet(command.Id,
                             command.Name,
                             command.Age,
                             command.Color,
                             command.SexOfPet,
                             breedId);
        await dbContext.Pets.AddAsync(newPet);
        await dbContext.SaveChangesAsync();
    }

    public async Task Handle(SetWeightCommand command)
    {
        var pet = await dbContext.Pets.FindAsync(command.Id);
        pet.SetWeight(command.Weight, breedService);
        await dbContext.SaveChangesAsync();
    }
}
