using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private int _count;

    private static List<string> _allPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are things that bring you a deep sense of peace?",
        "What are small victories or progress you've made recently?",
        "What are things that made you smile this week?"
    };

    private static List<string> _remainingPrompts = new List<string>(_allPrompts);
    private Random _random;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _count = 0;
        _random = new Random();
    }

    public string GetRandomPrompt()
    {
        if (_remainingPrompts.Count == 0)
        {
            _remainingPrompts = new List<string>(_allPrompts);
        }
        int index = _random.Next(_remainingPrompts.Count);
        string prompt = _remainingPrompts[index];
        _remainingPrompts.RemoveAt(index);
        return prompt;
    }

    public List<string> GetListFromUser()
    {
        List<string> userItems = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                userItems.Add(input);
            }

            if (DateTime.Now >= endTime)
            {
                break;
            }
        }

        _count = userItems.Count;
        return userItems;
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        GetListFromUser();

        Console.Write("\nProcessing");
        DateTime processStart = DateTime.Now;
        DateTime processEnd = processStart.AddSeconds(8);

        while (DateTime.Now < processEnd)
        {
            Thread.Sleep(1000);
            Console.Write(".");
        }
        Console.WriteLine();

        Console.WriteLine($"\nYou listed {_count} items.");
        DisplayEndingMessage();
    }
}