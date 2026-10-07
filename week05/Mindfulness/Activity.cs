using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How many seconds would you like for your session? ");

        string input = Console.ReadLine();
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive integer greater than 0: ");
            input = Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed the {_name} Activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        int i = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            i++;
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}