using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities;

public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Color { get; init; }
    public Weight Weight { get; init; }
    public SexOfPet SexOfPet { get; init; }
    public BreedId BreedId { get; init; }

    public Pet(Guid id,
               string name,
               int age,
               string color,
               Weight weight,
               SexOfPet sexOfPet,
               BreedId breedId)
    {
        Id = id;
        Name = name;
        Age = age;
        Color = color;
        Weight = weight;
        SexOfPet = sexOfPet;
        BreedId = breedId;
    }
}

public enum SexOfPet
{
    Male,
    Female
}