using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id, "Gianni", 13, "Three-color", SexOfPet.Male, breedId);
        var pet2 = new Pet(id, "Nina", 10, "Three-color",SexOfPet.Female, breedId);

        Assert.True(pet1.Equals(pet2));
    }
    
    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id, "Gianni", 13, "Three-color", SexOfPet.Male, breedId);
        var pet2 = new Pet(id, "Nina", 10, "Three-color", SexOfPet.Female, breedId);

        Assert.True(pet1 == pet2);
    }


    [Fact]
    public void Pet_should_not_be_equal_using_operators()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id1, "Gianni", 13, "Three-color", SexOfPet.Male, breedId);
        var pet2 = new Pet(id2, "Nina", 10, "Three-color", SexOfPet.Female, breedId);

        Assert.True(pet1 != pet2);
    }

    [Fact]
    public void Weight_should_be_equal()
    {
        var w1 = new Weight(20.5m);
        var w2 = new Weight(20.5m);
        Assert.True(w1 == w2);
    }

    [Fact]
    public void WeightRange_should_be_equal()
    {
        var wr1 = new WeightRange(10.5m, 20.5m);
        var wr2 = new WeightRange(10.5m, 20.5m);
        Assert.True(wr1 == wr2);
    }

    [Fact]
    public void BreedId_should_be_valid()
    {
        var breedService = new FakeBreedService();
        var id = breedService.breeds[0].Id;
        var breedId = new BreedId(id, breedService);
        Assert.NotNull(breedId);
    }

    [Fact]
    public void BreedId_should_not_be_valid()
    {
        var breedService = new FakeBreedService();
        var id = Guid.NewGuid();
        Assert.Throws<ArgumentException>(() =>
        {
            var breedId = new BreedId(id, breedService);
        });
    }

    [Fact]
    public void WeightClass_should_be_ideal()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet = new Pet(Guid.NewGuid(), "Gianni", 13, "Three-color", SexOfPet.Male, breedId);
        pet.SetWeight(new Weight(10), breedService);
        Assert.True(pet.WeightClass == WeightClass.Ideal);
    }

    [Fact]
    public void WeightClass_should_be_underweight()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet = new Pet(Guid.NewGuid(), "Gianni", 13, "Three-color", SexOfPet.Male, breedId);
        pet.SetWeight(new Weight(8), breedService);
        Assert.True(pet.WeightClass == WeightClass.Underweight);
    }

    [Fact]
    public void WeightClass_should_be_overweight()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet = new Pet(Guid.NewGuid(), "Gianni", 13, "Three-color", SexOfPet.Male, breedId);
        pet.SetWeight(new Weight(25), breedService);
        Assert.True(pet.WeightClass == WeightClass.Overweight);
    }
}