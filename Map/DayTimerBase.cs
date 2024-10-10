using Fractural.Tasks;
using Godot;

namespace FarewellToFate;


public partial class DayTimerBase : Node
{
    [Export] public Season Season { get; protected set; }
    [Export] public int Day { get; protected set; }
    [Export] public int Year { get; protected set; }
    [Export] public int Hour { get; protected set; }
    [Export] public int Minute { get; protected set; }


}



public partial class DayTimerServer : DayTimerBase, IAsyncStartable
{
    public override void _Ready()
    {
        base._Ready();
        FirstTimeSetup();

    }

    public async GDTask StartAsync()
    {
    }

    public void FirstTimeSetup()
    {
        Hour = 6;
        Minute = 0;
        Season = Season.Spring;
        Day = 1;
        Year = 1;
    }

    void AdvanceMinute()
    {
        Minute++;
        if (Minute >= 60)
        {
            Minute = 0;
            Hour++;
            if (Hour >= 24)
            {
                Hour = 0;
                Day++;
                if (Day > 30)
                {
                    Day = 1;
                    Season++;
                    if (Season > Season.Winter)
                    {
                        Season = Season.Spring;
                        Year++;
                    }
                }
            }
        }
    }


}