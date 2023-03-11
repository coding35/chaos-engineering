namespace CoreApp;

public class ChaosMonkey
{
    /// <summary>
    /// Michaels, P. (2022). 6. The Travel Rep Problem. In Software architecture by example: Using C# and .NET. essay, Apress.
    /// </summary>
    private readonly Random Random = new Random();

    public async Task CauseChaos()
    {
        Console.WriteLine($"\n\nChaosMonkey Invoked: {DateTime.Now}");
        int result = Random.Next(5);
        switch (result)
        {
            case 0:
                Console.WriteLine($"Throw exception immediately");
                throw new Exception("Failure");
            case 1:
                Console.WriteLine($"Wait, then throw exception");
                await Task.Delay(3000);
                throw new Exception("Failure");
            case 2:
                Console.WriteLine($"Wait, then work");
                await Task.Delay(3000);
                break;
        }
        Console.WriteLine("Call succeeded");
    }
}