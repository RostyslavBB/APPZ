public class ConsoleMenu
{
    private Game currentGame;
    private readonly int availableStorage;
    private readonly int availableRAM;
    private readonly int availableCPU;
    private readonly int availableGPU;
    private readonly bool isConnected;
    private readonly string systemOS;

    public ConsoleMenu(int storage, int ram, int cpu, int gpu, bool connected, string os)
    {
        availableStorage = storage;
        availableRAM = ram;
        availableCPU = cpu;
        availableGPU = gpu;
        isConnected = connected;
        systemOS = os;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Game Menu ===");
            Console.WriteLine("1. Install Game\n2. Start Game\n3. Save Game\n4. Load Game\n5. Stop Game\n6. Use Steering Wheel\n7. Play Online\n8. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    InstallGame();
                    break;
                case "2":
                    StartGame();
                    break;
                case "3":
                    currentGame?.SaveGame();
                    break;
                case "4":
                    currentGame?.LoadGame();
                    break;
                case "5":
                    currentGame?.Stop(ref currentGame);
                    break;
                case "6":
                    if (currentGame is SimulatorGame sim)
                        sim.UseSteeringWheel();
                    break;
                case "7":
                    if (currentGame is OnlineCasino oc)
                        oc.PlayOnline(isConnected);
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void InstallGame()
    {
        Console.WriteLine("1. Total War\n2. Flight Simulator\n3. PokerStars");
        Console.Write("Select a game to install: ");
        string installOption = Console.ReadLine();
        GameFactory.CreateGame(installOption)?.Install(availableStorage, systemOS);
    }

    private void StartGame()
    {
        Console.WriteLine("1. Total War\n2. Flight Simulator\n3. PokerStars");
        Console.Write("Select a game to start: ");
        string startOption = Console.ReadLine();

        Game game = GameFactory.CreateGame(startOption);
        if (game is OnlineCasino casino && !casino.CanStart(isConnected))
        {
            Console.WriteLine($"Cannot start {casino.Name}. Browser or internet connection missing.");
            return;
        }
        game?.Start(availableRAM, availableCPU, availableGPU, ref currentGame);
    }
}