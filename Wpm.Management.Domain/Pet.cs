namespace Wpm.Management.Domain;

public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }

    public Pet(Guid id)
    {
        Id = id;
    }
}
