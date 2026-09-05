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

        ///variables and conditionals to add the sign as required in the stretch challenge.
        string sign = "";
        int lastDigit = percentage % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit <= 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        ///conditional to remove the sign and recognize the special situation in A and F, part of the stretch challenge.
        if (percentage >= 95 || percentage < 60)
        {
            sign = "";
        }


        Console.WriteLine($"Your grade is {gradeLetter}{sign}.");

        
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