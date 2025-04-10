public class GameEventArgs : EventArgs
{
    public string GameName { get; }
    public string Action { get; }

    public GameEventArgs(string gameName, string action)
    {
        GameName = gameName;
        Action = action;
    }
}