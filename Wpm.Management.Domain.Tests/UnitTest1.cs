namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(id) { Name = "Gianni", Age = 13 };
        var pet2 = new Pet(id) { Name = "Nina", Age = 10 };

        Assert.True(pet1.Equals(pet2));
    }
    
    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(id);
        var pet2 = new Pet(id);

        Assert.True(pet1 == pet2);
    }


    [Fact]
    public void Pet_should_not_be_equal_using_operators()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();

        var pet1 = new Pet(id1);
        var pet2 = new Pet(id2);

        Assert.True(pet1 != pet2);
    }
}