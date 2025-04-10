public static class GameFactory
{
    private static readonly Dictionary<string, Game> cachedGames = new();
    private static Game lastInstalledSimulator;

    public static Game CreateGame(string type)
    {
        return type switch
        {
            "1" => cachedGames.TryGetValue("Strategy", out var strategy) ? strategy : cachedGames["Strategy"] = new StrategyGame("Total War"),
            "2" => lastInstalledSimulator ??= new SimulatorGame("Flight Simulator", true),
            "3" => cachedGames.TryGetValue("Casino", out var casino) ? casino : cachedGames["Casino"] = new OnlineCasino("PokerStars", true),
            _ => null
        };
    }

}
