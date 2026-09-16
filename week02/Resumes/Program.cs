using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello! This is the Angel's Resumes Project.");
        
        Console.Write("");

        Job jobOne = new Job();
        jobOne._jobTitle = "Software Engineer";
        jobOne._company = "Microsoft";
        jobOne._startYear = 2019;
        jobOne._endYear = 2022;

        Job jobTwo = new Job();
        jobTwo._jobTitle = "Manager";
        jobTwo._company = "Apple";
        jobTwo._startYear = 2022;
        jobTwo._endYear = 2023;

        Resume theResume = new Resume();
        theResume._name = "Allison Rose";

        theResume._jobs.Add(jobOne);
        theResume._jobs.Add(jobTwo);

        theResume.Display();
    }
}