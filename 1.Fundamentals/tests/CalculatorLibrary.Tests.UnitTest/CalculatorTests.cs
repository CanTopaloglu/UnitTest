using FluentAssertions;
using Xunit.Abstractions;

namespace CalculatorLibrary.Tests.UnitTest;

public class CalculatorTests : IDisposable, IAsyncLifetime
{
    #region Arrange
    //Arrange kýsmý
    private readonly Calculator _sut = new(); //system under test anlamýnda.
    private readonly Guid _guid = Guid.NewGuid();

    private readonly ITestOutputHelper _outputHelper;

    public CalculatorTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _outputHelper.WriteLine("Constructor is working...");
    }

    public async Task InitializeAsync()  //Method çalýþmadan hemen öncesine müdahale ediyor (ilk çalýþan) 
    {
        _outputHelper.WriteLine("InitializeAsync is working...");
        await Task.Delay(1);

        //Bir  database'e baðlanmak, bir þey set etmek istersem Constructor veya initializeAsync'i kullanabilirim.
    }
    #endregion

    [Fact] 
    public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreInteger()
    {
        //Arrange buraya da yazýlabiliyor.

        //Act iþlemi gerçekleþtirip sonucu yakaladýðýmýz kýsým.
        var result = _sut.Add(2, 7);

        //Assert - þart kýsmýmýz, Assert kýsmýdýr. Þartý belirleriz.

        //Assert.Equal(9, result);
        result.Should().Be(9);
        result.Should().NotBe(7);
    }

    [Fact]
    public void Substract_ShouldSubstractTwoNumbers_WhenTwoNumbersAreInteger()
    {
        //Act
        var result = _sut.Substract(7, 2);

        //Assert
        //Assert.Equal(5, result);

        result.Should().Be(5);
        result.Should().NotBe(7);
    }

    [Fact]
    public void Multiply_ShouldMultiplyTwoNumbers_WhenTwoNumbersAreInteger()
    {
        //Act

        var result = _sut.Multiply(1, 3);

        //Assert
        result.Should().Be(3);
    }

    [Theory]
    [InlineData(6,2,3)]
    [InlineData(8,2,4)]
    [InlineData(0,0,0,Skip = "Sýfýt sýfýra bölünemez")]
    public void Divide_ShouldDivideTwoNumbers_WhenTwoNumbersAreInteger(int a, int b, int expected)
    {
        //Act
        var result = _sut.Divide(a, b); //  0,0 -  5,2 versek ne olacak?
        
        //Assert
        result.Should().Be(expected);
    }

    #region Test
    [Fact(Skip = "Bu metot artýk kullanýlmýyor.")]
    public void Test1()
    {
        _outputHelper.WriteLine(_guid.ToString());
    }

    [Fact(Skip = "Bu metot artýk kullanýlmýyor.")]
    public void Test2()
    {
        _outputHelper.WriteLine(_guid.ToString());
    }
    #endregion


    #region Dispose
    public void Dispose() // Genelde integration testlerde yazýlýr. Method çalýþmayý bitirdikten sonra çalýþýyor.
    {
        _outputHelper.WriteLine("Dispose is working...");

        //Ýþlem sonunda bir dosya silmek veya dispose etmek istiyorsam - Dispose ve DisposeAsync kullanýyorum
    }

    public async Task DisposeAsync() //Method çalýþtýktan sonra çalýþýyor
    {
        _outputHelper.WriteLine("DisposeAsync is working...");
        await Task.Delay(1);
    }
    #endregion

}

//Clean code
//kodun okunabilir olmasý
//kodun daha az olmasý, tekrardan arýndýrýlmýþ olmasý
//Kütüphane FluentAssertions.

//Fact içerisine (Skip = "Bu metot artýk kullanýlmýyor.") //Skip yazarak bu testi silmek yerine yapmayacaðýmýzý belirtebiliyoruz.
//Birden fazla parametre göndereceksem [Theory]'i kullanýyorum.
//UnitTestler 3 parçadan oluþur. 