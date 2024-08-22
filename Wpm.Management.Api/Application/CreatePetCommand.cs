using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Api.Application;

public record CreatePetCommand(Guid Id,
                               string Name,
                               int Age,
                               string Color,
                               SexOfPet SexOfPet,
                               Guid BreedId);

