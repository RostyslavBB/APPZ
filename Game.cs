public abstract class Game
{
    public static GameEventNotifier Notifier = new GameEventNotifier();

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
        IsInstalled = platform == "Browser";
    }

    public virtual void Install(int availableStorage, string systemOS)
    {
        if (Platform == "Browser")
        {
            Notifier.Notify(Name, "Already available in browser, no installation needed.");
            return;
        }
        if (systemOS != "Windows")
        {
            Notifier.Notify(Name, "Installation failed: unsupported OS.");
            return;
        }
        if (availableStorage < RequiredStorage)
        {
            Notifier.Notify(Name, "Installation failed: not enough storage.");
            return;
        }
        IsInstalled = true;
        Notifier.Notify(Name, "Installed successfully.");
    }

    public virtual void Start(int availableRAM, int availableCPU, int availableGPU, ref Game currentGame)
    {
        if (!IsInstalled)
        {
            Notifier.Notify(Name, "Start failed: game not installed.");
            return;
        }
        if (Platform != "Browser" && (availableRAM < RequiredRAM || availableCPU < RequiredCPU || availableGPU < RequiredGPU))
        {
            Notifier.Notify(Name, "Start failed: system requirements not met.");
            return;
        }
        if (currentGame != null && currentGame.IsRunning)
        {
            Notifier.Notify(Name, "Start failed: another game is already running.");
            return;
        }

        IsRunning = true;
        currentGame = this;
        Notifier.Notify(Name, "Started");
    }

    public void SaveGame()
    {
        if (IsRunning)
        {
            IsSaved = true;
            Notifier.Notify(Name, "Saved");
        }
        else
        {
            Notifier.Notify(Name, "Save failed: game is not running.");
        }
    }

    public void LoadGame()
    {
        if (IsSaved)
        {
            Notifier.Notify(Name, "Loaded");
        }
        else
        {
            Notifier.Notify(Name, "Load failed: no saved state available.");
        }
    }

    public void Stop(ref Game currentGame)
    {
        if (IsRunning)
        {
            IsRunning = false;
            currentGame = null;
            Notifier.Notify(Name, "Stopped");
        }
        else
        {
            Notifier.Notify(Name, "Stop failed: game is not running.");
        }
    }
}