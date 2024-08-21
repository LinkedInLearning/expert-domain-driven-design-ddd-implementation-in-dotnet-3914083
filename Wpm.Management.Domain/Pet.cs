namespace Wpm.Management.Domain;

public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Color { get; init; }
    public Weight Weight { get; init; }
    public SexOfPet SexOfPet { get; init; }

    public Pet(Guid id,
               string name,
               int age,
               string color,
               Weight weight,
               SexOfPet sexOfPet)
    {
        Id = id;
        Name = name;
        Age = age;
        Color = color;
        Weight = weight;
        SexOfPet = sexOfPet;
    }
}

public enum SexOfPet
{
    Male,
    Female
}