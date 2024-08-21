namespace Wpm.Management.Domain;
public class Breed : Entity
{
    public string Name { get; init; }
    public WeightRange MaleIdealWeight { get; init; }
    public WeightRange FemaleIdealWeight { get; init; }

    public Breed(string name,
                 WeightRange maleIdealWeight,
                 WeightRange femaleIdealWeight)
    {
        Name = name;
        MaleIdealWeight = maleIdealWeight;
        FemaleIdealWeight = femaleIdealWeight;
    }
}

public record WeightRange
{
    public decimal From { get; init; }
    public decimal To { get; init; }
    public WeightRange(decimal from, decimal to)
    {
        From = from;
        To = to;
    }
}
