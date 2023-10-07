namespace Mediator.Chat;

public interface IMediator
{
    void Send(string message, ICollage collage);
}