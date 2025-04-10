public class Logger
{
    public void OnGameEvent(object sender, GameEventArgs e)
    {
        Console.WriteLine($"[INFO] Game '{e.GameName}' -> {e.Action}");
    }

    public void Subscribe(GameEventNotifier notifier)
    {
        notifier.GameEventOccurred += OnGameEvent;
    }

    public void Unsubscribe(GameEventNotifier notifier)
    {
        notifier.GameEventOccurred -= OnGameEvent;
    }
}
