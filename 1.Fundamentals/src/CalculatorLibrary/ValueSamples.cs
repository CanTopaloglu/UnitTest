namespace CalculatorLibrary;
public class ValueSamples
{
    public string FullName = "Emre Can";

    public int Age = 28;

    public User user = new()
    {
        FullName = "Emre Can",
        Age = 28,
        DateOfBirth = new(1996, 01, 05) //DateOnly verirsek bunu newleyebiliyoruz.
    };

    public IEnumerable<User> Users = new[]
    {
        new User()
        {
            FullName = "Emre Can",
            Age = 28,
            DateOfBirth = new(1996, 01, 05)
        },
        new User()
        {
            FullName = "Enes Demirtaş",
            Age = 28,
            DateOfBirth = new(1996, 04, 25)
        },
        new User()
        {
            FullName = "Yilmaz Kuneri",
            Age = 28,
            DateOfBirth= new(1996, 03, 06)
        }
    };

    public IEnumerable<int> Numbers = new[] { 5, 10, 25, 50 };

    public float Divide(int a, int b)
    {
        if(a == 0 || b == 0) 
        {
            throw new DivideByZeroException();
        }
            
        return a / b;
    }

    public event EventHandler ExampleEvent;
    public virtual void RaiseExampleEvent()
    {
        ExampleEvent(this, EventArgs.Empty);
    }

    internal int InternalSecretNumber = 42;
    
}

public sealed class User
{
    public string FullName { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateOnly DateOfBirth { get; set; }
}
