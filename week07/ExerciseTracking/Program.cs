using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold activities
        List<Activity> activities = new List<Activity>();

        // Instantiate at least 2 instances for each available activity type
        Running run1 = new Running("03 Nov 2022", 30, 4.8);
        Running run2 = new Running("06 Nov 2022", 45, 7.2);

        Cycling cycle1 = new Cycling("04 Nov 2022", 40, 19.2);
        Cycling cycle2 = new Cycling("07 Nov 2022", 60, 25.0);

        Swimming swim1 = new Swimming("05 Nov 2022", 25, 20);
        Swimming swim2 = new Swimming("08 Nov 2022", 35, 30);

        // Add all of them to the same list
        activities.Add(run1);
        activities.Add(run2);
        activities.Add(cycle1);
        activities.Add(cycle2);
        activities.Add(swim1);
        activities.Add(swim2);

        // Iterate through the list and display summaries polymorphically
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}