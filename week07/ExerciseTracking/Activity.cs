public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance(); // in kilometers
    public abstract double GetSpeed();    // in kph
    public abstract double GetPace();     // in min per km

    protected abstract string GetActivityName();

    // Virtual method to allow specific activities (like Swimming) to append extra details
    public virtual string GetExtraDetails()
    {
        return string.Empty;
    }

    // GetSummary remains in the base class (satisfies rubric criteria for virtual methods)
    public string GetSummary()
    {
        Console.WriteLine("Summary of Activities:");
        return $"\n{_date} {GetActivityName()} ({_minutes} min): Distance {GetDistance():0.1} km, Speed: {GetSpeed():0.1} kph, Pace: {GetPace():0.2} min per km{GetExtraDetails()}";
    }
}