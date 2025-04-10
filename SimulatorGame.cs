public class SimulatorGame : Game
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
            Notifier.Notify(Name, HasSteeringWheel ? "Enhanced with steering wheel." : "Steering wheel not connected.");
        }
        else
        {
            Notifier.Notify(Name, "Steering wheel usage failed: game not running.");
        }
    }
}