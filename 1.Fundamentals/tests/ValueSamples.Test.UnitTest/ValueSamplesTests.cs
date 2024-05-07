namespace ValueSamples.Test.UnitTest;

using CalculatorLibrary;
using FluentAssertions;
using ValueSamples = CalculatorLibrary.ValueSamples;
public class ValueSamplesTests
{
    //Arrange
    private readonly ValueSamples  _sut = new();

    [Fact]
    public void StringAssertionExample()
    {
        //Act
        var fullName = _sut.FullName;

        //Assert
        fullName.Should().Be("Emre Can");
        fullName.Should().NotBeEmpty();
        fullName.Should().StartWith("Emre");
        fullName.Should().EndWith("Can");
    }

    [Fact]
    public void NumberAssertionExample()
    {
        //Act
        var age = _sut.Age;

        //Assert
        age.Should().Be(28);
        age.Should().BePositive();
        age.Should().BeGreaterThan(20);
        age.Should().BeLessThanOrEqualTo(28);
        age.Should().BeInRange(20, 50);
    }

    [Fact]
    public void ObjectAssertionExample()
    {
        //Act
        var expectedUser = new User() //içerisi birebir aynı, referans 101
        {
            FullName = "Emre Can",
            Age = 28,
            DateOfBirth = new(1996, 01, 05)
        };

        var user = _sut.user; // referans 102 , referanslar aynı ise değer de aynıdır.

        //Assert
        user.Should().BeEquivalentTo(expectedUser); 
        
        
        //out , ref  keywordleri
        //BeEquivalentTo  referans'ı siliyor ve sadece değer üzerinden kontrol yapıyor.
    }

    [Fact]
    public void EnumerableObjectAssertionExample()
    {
        //Arrange
        var expected = new User
        {
            FullName = "Emre Can",
            Age = 28,
            DateOfBirth = new(1996, 01, 05)
        };

        //Act
        var users = _sut.Users.As<User[]>();

        //Assert
        users.Should().ContainEquivalentOf(expected);
        users.Should().HaveCount(3);
        users.Should().Contain(x => x.FullName.StartsWith("Enes") && x.Age > 25);
    }

    [Fact]
    public void EnumerableNumberAssertionExample()
    {
        //Act
        var numbers = _sut.Numbers.As<int[]>();

        //Assert
        numbers.Should().Contain(5);
        
    }

    [Fact]
    public void ExceptionThrownAssertionExample()
    {
        //Act
        Action result = () => _sut.Divide(1, 0);

        //Assert
        result.Should().Throw<DivideByZeroException>();
         //.WithMessage("Attempted to divide by zero.");
    }

    [Fact]
    public void EventRaisedAssertionExample()
    {
        //Arrange
        var monitorSubject = _sut.Monitor();

        //Act
        _sut.RaiseExampleEvent();

        //Assert
        monitorSubject.Should().Raise("ExampleEvent");
    }

    [Fact]
    public void TestingInternalMembersExample()
    {
        //Act
        var number = _sut.InternalSecretNumber;

        //Assert

        number.Should().Be(42);
    }
    
}
