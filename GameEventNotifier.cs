public class GameEventNotifier
{
    public event EventHandler<GameEventArgs> GameEventOccurred;

    public void Notify(string gameName, string action)
    {
        GameEventOccurred?.Invoke(this, new GameEventArgs(gameName, action));
    }
}