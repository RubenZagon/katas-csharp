namespace Mediator.Chat;

class UserAdmin : ICollage
{
    public UserAdmin(Mediator mediator) : base(mediator)
    {
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"Admin received: {message}");
        Thread.Sleep(1500);
    }
}