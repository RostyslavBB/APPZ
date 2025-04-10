class Program
{
    static void Main()
    {
        Logger logger = new Logger();
        logger.Subscribe(Game.Notifier);

        ConsoleMenu menu = new ConsoleMenu(
            storage: 200,
            ram: 16,
            cpu: 6,
            gpu: 4,
            connected: true,
            os: "Windows"
        );

        menu.Run();
    }
    }