namespace Wpm.Management.Domain;

public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Color { get; set; }
    public decimal Weight { get; set; }
    public SexOfPet SexOfPet { get; set; }
    public Pet(Guid id)
    {
        Id = id;
    }
}

public enum SexOfPet
{
    Male,
    Female
}