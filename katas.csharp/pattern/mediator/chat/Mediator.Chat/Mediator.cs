namespace Mediator.Chat;

class Mediator : IMediator
{
    private List<ICollage> _collages = new();

    public void Add(ICollage collage)
    {
        _collages.Add(collage);
    }

    public void Send(string message, ICollage collage)
    {
        foreach (var item in _collages.Where(x => x != collage))
        {
            item.Receive(message);
        }
    }
}