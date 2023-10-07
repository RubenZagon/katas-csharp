namespace Mediator.Chat;

public abstract class ICollage
{
    private IMediator _mediator { get; }

    protected ICollage(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Communicate(string message)
    {
        _mediator.Send(message, this);
    }

    public abstract void Receive(string message);
}