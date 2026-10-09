using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello again! Here is the EternalQuest Project.");

        GoalManager manager = new GoalManager();
        manager.Start();
        
        // Exceeding Requirements Description:
        // - Allowed non-zero positive and negative values when configuring goal points.
        // - Enhanced file serialization using pipe delimiters (|) to prevent comma-splitting errors in descriptions.
        // - Added an interactive leveling system with descriptive titles corresponding.
        // - Added user profile registration, with gender unlocking titles.
        // - Added a menu option enabling users to modify existing goals.
    }
}
