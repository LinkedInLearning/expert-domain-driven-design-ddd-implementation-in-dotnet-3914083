using Wpm.Management.Domain;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Application;

public class ManagementApplicationService(IBreedService breedService)
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

    }
}
