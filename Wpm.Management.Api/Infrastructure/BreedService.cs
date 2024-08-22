using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;
using Wpm.Management.Domain;

namespace Wpm.Management.Api.Infrastructure;

public class BreedService : IBreedService
{
    public readonly List<Breed> breeds =
       [
            new Breed (Guid.Parse("1c10f44e-83b1-4094-b6b1-4298991d9d71"), "Beagle", new WeightRange(10m, 20m), new WeightRange (11m, 18m)),
            new Breed (Guid.Parse("63386cae-79c2-4180-8630-60c6cdf2f5f1"), "Staffordshire Terrier", new WeightRange(28m, 40m), new WeightRange (24m,34m))
       ];

    public Breed? GetBreed(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Breed is not valid.");
        }
        var result = breeds.Find(breeds => breeds.Id == id);
        return result ?? throw new ArgumentException("Breed was not found.");
    }
}