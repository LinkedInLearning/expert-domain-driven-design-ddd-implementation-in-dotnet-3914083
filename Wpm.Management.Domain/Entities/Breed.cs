using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities;
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
