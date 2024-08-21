using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(id, "Gianni", 13, "Three-color", new Weight(20.5m), SexOfPet.Male);
        var pet2 = new Pet(id, "Nina", 10, "Three-color", new Weight(18.5m), SexOfPet.Female);

        Assert.True(pet1.Equals(pet2));
    }
    
    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(id, "Gianni", 13, "Three-color", new Weight(20.5m), SexOfPet.Male);
        var pet2 = new Pet(id, "Nina", 10, "Three-color", new Weight(18.5m), SexOfPet.Female);

        Assert.True(pet1 == pet2);
    }


    [Fact]
    public void Pet_should_not_be_equal_using_operators()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();

        var pet1 = new Pet(id1, "Gianni", 13, "Three-color", new Weight(20.5m), SexOfPet.Male);
        var pet2 = new Pet(id2, "Nina", 10, "Three-color", new Weight(18.5m), SexOfPet.Female);

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
}