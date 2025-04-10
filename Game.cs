abstract class Game
{
    public string Name { get; }
    public string Platform { get; }
    public int RequiredRAM { get; }
    public int RequiredStorage { get; }
    public int RequiredCPU { get; }
    public int RequiredGPU { get; }
    public bool IsInstalled { get; private set; }
    public bool IsRunning { get; private set; }
    public bool IsSaved { get; private set; }

    protected Game(string name, string platform, int ram, int storage, int cpu, int gpu)
    {
        Name = name;
        Platform = platform;
        RequiredRAM = ram;
        RequiredStorage = storage;
        RequiredCPU = cpu;
        RequiredGPU = gpu;
        IsInstalled = platform == "Browser"; // Браузерні ігри не потрібно встановлювати
    }

    public void Install(int availableStorage, string systemOS)
    {
        if (Platform == "Browser")
        {
            Console.WriteLine($"{Name} does not require installation.");
            return;
        }
        if (systemOS != "Windows")
        {
            Console.WriteLine($"Cannot install {Name}, it requires Windows.");
            return;
        }
        if (availableStorage < RequiredStorage)
            Console.WriteLine($"Not enough storage to install {Name}.");
        else
        {
            IsInstalled = true;
            Console.WriteLine($"{Name} installed successfully.");
        }
    }

    public void Start(int availableRAM, int availableCPU, int availableGPU, ref Game currentGame)
    {
        if (!IsInstalled)
        {
            Console.WriteLine($"Game {Name} is not installed!");
            return;
        }
        if (Platform == "Browser")
        {
            Console.WriteLine($"{Name} launched in browser.");
            currentGame = this;
            return;
        }
        if (availableRAM < RequiredRAM || availableCPU < RequiredCPU || availableGPU < RequiredGPU)
        {
            Console.WriteLine($"Not enough system resources to run {Name}.");
            return;
        }
        if (currentGame != null && currentGame.IsRunning)
        {
            Console.WriteLine($"Cannot start {Name} while {currentGame.Name} is running.");
            return;
        }
        IsRunning = true;
        currentGame = this;
        Console.WriteLine($"{Name} started.");
    }

    public void SaveGame()
    {
        if (IsRunning)
        {
            IsSaved = true;
            Console.WriteLine($"{Name} saved.");
        }
        else
            Console.WriteLine($"Cannot save {Name}, as it is not running!");
    }

    public void LoadGame()
    {
        if (IsSaved)
            Console.WriteLine($"{Name} loaded successfully.");
        else
            Console.WriteLine($"No saved data to load for {Name}.");
    }

    public void Stop(ref Game currentGame)
    {
        if (IsRunning)
        {
            IsRunning = false;
            currentGame = null;
            Console.WriteLine($"{Name} closed.");
        }
    }
}