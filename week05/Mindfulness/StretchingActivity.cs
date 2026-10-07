using System;
using System.Threading;

public class StretchingActivity : Activity
{
    public StretchingActivity()
    {
        _name = "Stretching and Physical Focus";
        _description = "This activity will help release physical tension by stretching your back and sides. Extend your arms to alternate sides to loosen up your muscles.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        if (_duration < 20)
        {
            _duration = 20;
            Console.WriteLine("\nAdjusting duration to a minimum of 20 seconds to complete the stretching cycles.");
            ShowSpinner(2);
        }

        int prepTime = 5;

        int totalPrepTimeNeeded = prepTime * 2;
        if (_duration <= totalPrepTimeNeeded)
        {
            _duration = totalPrepTimeNeeded + 10;
        }

        int netStretchTime = _duration - (prepTime * 2);
        int timePerSide = netStretchTime / 2;

        Console.WriteLine("\n--- Stretch your right arm up and reach to the left side ---");
        Console.Write("Get ready... ");
        ShowCountDown(prepTime);
        Console.WriteLine();

        RunCustomCountdown("Stretch... ", timePerSide);

        Console.WriteLine("\n--- Stretch your left arm up and reach to the right side ---");
        Console.Write("Get ready... ");
        ShowCountDown(prepTime);
        Console.WriteLine();

        RunCustomCountdown("Stretch... ", timePerSide);

        DisplayEndingMessage();
    }

    private void RunCustomCountdown(string message, int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{message}{i}");
            Thread.Sleep(1000);

            Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
        }
        Console.WriteLine($"{message}Done!");
    }
}