class Program
{
    static void Main()
    {
        StrategyGame strategy = new StrategyGame("Total War");
        SimulatorGame simulator = new SimulatorGame("Flight Simulator", true);
        OnlineCasino casino = new OnlineCasino("PokerStars", true);

        int availableStorage = 200;
        int availableRAM = 16;
        int availableCPU = 6;
        int availableGPU = 4;
        bool isConnected = true;
        string systemOS = "Windows";
        Game currentGame = null;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Game Menu ===");
            Console.WriteLine("1. Install Game");
            Console.WriteLine("2. Start Game");
            Console.WriteLine("3. Save Game");
            Console.WriteLine("4. Load Game");
            Console.WriteLine("5. Stop Game");
            Console.WriteLine("6. Use Steering Wheel");
            Console.WriteLine("7. Play Online");
            Console.WriteLine("8. Exit");

            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Available Games:");
                    Console.WriteLine("1. Total War");
                    Console.WriteLine("2. Flight Simulator");
                    Console.WriteLine("3. PokerStars");
                    Console.Write("Select a game to install: ");
                    string installOption = Console.ReadLine();
                    if (installOption == "1")
                        strategy.Install(availableStorage, systemOS);
                    else if (installOption == "2")
                        simulator.Install(availableStorage, systemOS);
                    else if (installOption == "3")
                        casino.Install(availableStorage, systemOS);
                    break;

                case "2":
                    Console.WriteLine("Available Games:");
                    Console.WriteLine("1. Total War");
                    Console.WriteLine("2. Flight Simulator");
                    Console.WriteLine("3. PokerStars");
                    Console.Write("Select a game to start: ");
                    string startOption = Console.ReadLine();
                    if (startOption == "1")
                        strategy.Start(availableRAM, availableCPU, availableGPU, ref currentGame);
                    else if (startOption == "2")
                        simulator.Start(availableRAM, availableCPU, availableGPU, ref currentGame);
                    else if (startOption == "3")
                        casino.Start(availableRAM, availableCPU, availableGPU, ref currentGame);
                    break;

                case "3":
                    if (currentGame != null)
                        currentGame.SaveGame();
                    break;

                case "4":
                    if (currentGame != null)
                        currentGame.LoadGame();
                    break;

                case "5":
                    if (currentGame != null)
                        currentGame.Stop(ref currentGame);
                    break;

                case "6":
                    if (currentGame != null && currentGame is SimulatorGame simGame)
                        simGame.UseSteeringWheel();
                    break;

                case "7":
                    if (currentGame != null && currentGame is OnlineCasino)
                        casino.PlayOnline(isConnected);
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

}