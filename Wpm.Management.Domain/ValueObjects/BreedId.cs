namespace Wpm.Management.Domain.ValueObjects;
public record BreedId
{
    private readonly IBreedService breedService;

    public Guid Value { get; set; }
    
    private BreedId(Guid value)
    {
        Value = value;
    }

    public static BreedId Create(Guid value)
    {
        return new BreedId(value);
    }
    public BreedId(Guid value, IBreedService breedService)
    {
        this.breedService = breedService;

        ValidateBreed(value);

        Value = value;
        
    }

    private void ValidateBreed(Guid value)
    {
        if (breedService.GetBreed(value) == null)
        {
            throw new ArgumentException("Breed is not valid.");
        }
    }
}