namespace Wpm.Clinic.Domain.ValueObjects;
public record DrugId
{
    public Guid Value { get; init; }
    public DrugId(Guid value)
    {
        Value = value;
    }
}