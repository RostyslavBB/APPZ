public class OnlineCasino : Game
{
    public bool HasBrowser { get; }

    public OnlineCasino(string name, bool hasBrowser) : base(name, "Browser", 0, 0, 0, 0)
    {
        HasBrowser = hasBrowser;
    }

    public bool CanStart(bool isConnected) => HasBrowser && isConnected;

    public void PlayOnline(bool isConnected)
    {
        if (CanStart(isConnected))
        {
            Notifier.Notify(Name, "Playing online.");
        }
        else
        {
            Notifier.Notify(Name, "Online play failed: no connection or browser not available.");
        }
    }
}