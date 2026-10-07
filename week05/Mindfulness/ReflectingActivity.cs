using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private static List<string> _allPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you learned a valuable lesson from a mistake.",
        "Think of a time when you stayed calm during a stressful situation.",
        "Think of a time when you encouraged someone who was feeling down.",
        "Think of a time when you achieved a goal through hard work and persistence."
    };

    private static List<string> _allQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other similar times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private static List<string> _remainingPrompts = new List<string>(_allPrompts);
    private static List<string> _remainingQuestions = new List<string>(_allQuestions);
    private Random _random;

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
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

    public string GetRandomQuestion()
    {
        if (_remainingQuestions.Count == 0)
        {
            _remainingQuestions = new List<string>(_allQuestions);
        }
        int index = _random.Next(_remainingQuestions.Count);
        string question = _remainingQuestions[index];
        _remainingQuestions.RemoveAt(index);
        return question;
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue...");
        Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(10);
            Console.WriteLine();

            if (DateTime.Now >= endTime) break;
        }

        DisplayEndingMessage();
    }
}