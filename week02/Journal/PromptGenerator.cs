using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts { get; set; } = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the Lord's hand in my life today?",
        "What was the most intense emotion I felt today?",
        "What small or big accomplishment did I achieve today?",
        "What important lesson did I learn today?",
        "Did I give thanks for anything today? What was it?",
        "Did I feel closer to God today? Why?",
        "Who was the person I missed the most today? Have I told them that?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}