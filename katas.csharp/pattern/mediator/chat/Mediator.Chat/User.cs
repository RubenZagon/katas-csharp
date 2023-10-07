namespace Mediator.Chat;

class User : ICollage
{
    public User(Mediator mediator) : base(mediator)
    {
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"User received: {message}");
        Thread.Sleep(1000);
    }
}