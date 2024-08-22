using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain;

namespace Wpm.Management.Api.Application;

public class SetWeightCommandHandler(ManagementDbContext dbContext,
                                     IBreedService breedService) : ICommandHandler<SetWeightCommand>
{
    public async Task Handle(SetWeightCommand command)
    {
        var pet = await dbContext.Pets.FindAsync(command.Id);
        pet.SetWeight(command.Weight, breedService);
        await dbContext.SaveChangesAsync();
    }
}