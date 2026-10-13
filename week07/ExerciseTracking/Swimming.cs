public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance (km) = swimming laps * 50 / 1000
        return _laps * 50.0 / 1000;
    }

    public override double GetSpeed()
    {
        // Speed (kph) = (distance / minutes) * 60
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        // Pace (min per km) = minutes / distance
        return GetMinutes() / GetDistance();
    }

    protected override string GetActivityName()
    {
        return "Swimming";
    }

    // Overrides GetExtraDetails to include the number of laps achieved in the summary
    public override string GetExtraDetails()
    {
        return $", Laps: {_laps}";
    }
}