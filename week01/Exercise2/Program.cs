using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Team! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        string userAnswer = Console.ReadLine();
        int percentage = int.Parse(userAnswer);

        string gradeLetter = "";

        if (percentage >= 90)
        {
           gradeLetter= "A";
        }
        else if (percentage >= 80)
        {
            gradeLetter ="B";
        }
        else if (percentage >= 70)
        {
            gradeLetter ="C";
        }
        else if (percentage >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        Console.WriteLine($"Your grade is {gradeLetter}.");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed!.");
        }
        else
        {
            Console.WriteLine("You didn't reach your goal this time, but with hard work, you'll get there. ");
        }
    }
}