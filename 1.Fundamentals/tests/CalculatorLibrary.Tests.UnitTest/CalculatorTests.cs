using FluentAssertions;
using Xunit.Abstractions;

namespace CalculatorLibrary.Tests.UnitTest;

public class CalculatorTests : IDisposable, IAsyncLifetime
{
    #region Arrange
    //Arrange k�sm�
    private readonly Calculator _sut = new(); //system under test anlam�nda.
    private readonly Guid _guid = Guid.NewGuid();

    private readonly ITestOutputHelper _outputHelper;

    public CalculatorTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _outputHelper.WriteLine("Constructor is working...");
    }

    public async Task InitializeAsync()  //Method �al��madan hemen �ncesine m�dahale ediyor (ilk �al��an) 
    {
        _outputHelper.WriteLine("InitializeAsync is working...");
        await Task.Delay(1);

        //Bir  database'e ba�lanmak, bir �ey set etmek istersem Constructor veya initializeAsync'i kullanabilirim.
    }
    #endregion

    [Fact] 
    public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreInteger()
    {
        //Arrange buraya da yaz�labiliyor.

        //Act i�lemi ger�ekle�tirip sonucu yakalad���m�z k�s�m.
        var result = _sut.Add(2, 7);

        //Assert - �art k�sm�m�z, Assert k�sm�d�r. �art� belirleriz.

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
    [InlineData(0,0,0,Skip = "S�f�t s�f�ra b�l�nemez")]
    public void Divide_ShouldDivideTwoNumbers_WhenTwoNumbersAreInteger(int a, int b, int expected)
    {
        //Act
        var result = _sut.Divide(a, b); //  0,0 -  5,2 versek ne olacak?
        
        //Assert
        result.Should().Be(expected);
    }

    #region Test
    [Fact(Skip = "Bu metot art�k kullan�lm�yor.")]
    public void Test1()
    {
        _outputHelper.WriteLine(_guid.ToString());
    }

    [Fact(Skip = "Bu metot art�k kullan�lm�yor.")]
    public void Test2()
    {
        _outputHelper.WriteLine(_guid.ToString());
    }
    #endregion


    #region Dispose
    public void Dispose() // Genelde integration testlerde yaz�l�r. Method �al��may� bitirdikten sonra �al���yor.
    {
        _outputHelper.WriteLine("Dispose is working...");

        //��lem sonunda bir dosya silmek veya dispose etmek istiyorsam - Dispose ve DisposeAsync kullan�yorum
    }

    public async Task DisposeAsync() //Method �al��t�ktan sonra �al���yor
    {
        _outputHelper.WriteLine("DisposeAsync is working...");
        await Task.Delay(1);
    }
    #endregion

}

//Clean code
//kodun okunabilir olmas�
//kodun daha az olmas�, tekrardan ar�nd�r�lm�� olmas�
//K�t�phane FluentAssertions.

//Fact i�erisine (Skip = "Bu metot art�k kullan�lm�yor.") //Skip yazarak bu testi silmek yerine yapmayaca��m�z� belirtebiliyoruz.
//Birden fazla parametre g�ndereceksem [Theory]'i kullan�yorum.
//UnitTestler 3 par�adan olu�ur. 