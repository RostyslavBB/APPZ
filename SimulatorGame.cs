class SimulatorGame : Game
{
    public bool HasSteeringWheel { get; set; }

    public SimulatorGame(string name, bool hasSteeringWheel) : base(name, "Windows", 12, 100, 6, 4)
    {
        HasSteeringWheel = hasSteeringWheel;
    }

    public void UseSteeringWheel()
    {
        if (IsRunning)
        {
            Console.WriteLine(HasSteeringWheel ? $"{Name} is enhanced with steering wheel." : $"{Name} can be played, but a steering wheel would improve it.");
        }
        else
        {
            Console.WriteLine($"Cannot use steering wheel, {Name} is not running!");
        }
    }
}