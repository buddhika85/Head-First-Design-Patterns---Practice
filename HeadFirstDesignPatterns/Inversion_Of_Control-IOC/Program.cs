new IOC().Greet("Buddhika", () => { Console.WriteLine("Program Finished."); });

class IOC
{
    public void Greet(string name, Action callback)
    {
        Console.WriteLine($"Hello: {name} !");

        callback();
    }
}