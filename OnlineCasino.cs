class OnlineCasino : Game
{
    public bool HasBrowser { get; }

    public OnlineCasino(string name, bool hasBrowser) : base(name, "Browser", 0, 0, 0, 0)
    {
        HasBrowser = hasBrowser;
    }

    public void PlayOnline(bool isConnected)
    {
        if (!HasBrowser)
        {
            Console.WriteLine($"Cannot play {Name} because no browser is available.");
            return;
        }
        if (!isConnected)
        {
            Console.WriteLine($"Cannot play {Name} without an internet connection.");
            return;
        }
        Console.WriteLine($"Playing {Name} online.");
    }
}