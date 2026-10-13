public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        // Distance (km) = (speed * minutes) / 60
        return (_speed * GetMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        // Pace (min per km) = 60 / speed
        return 60 / _speed;
    }

    protected override string GetActivityName()
    {
        return "Cycling";
    }
}