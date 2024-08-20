namespace Wpm.Management.Domain;

public class Pet : IEquatable<Pet>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public bool Equals(Pet? other)
    {
        return other?.Id == Id;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Pet);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    public static bool operator ==(Pet? left, Pet? right)
    {
        return left?.Id == right?.Id;
    }

    public static bool operator !=(Pet? left, Pet? right)
    {
        return left?.Id != right?.Id;
    }
}
