namespace Wpm.SharedKernel;
public class DomainEventDispatcher<T> where T : IDomainEvent
{
    private List<Action<T>> Actions { get; } = new();

    public void Subscribe(Action<T> action)
    {
        if (Actions.Exists(a => a.Method == action.Method))
        {
            return;
        }

        Actions.Add(action);
    }

    public void Publish(T args)
    {
        foreach (var action in Actions)
        {
            action.Invoke(args);
        }
    }
}