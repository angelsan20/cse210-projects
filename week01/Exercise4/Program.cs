using System;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)

    {
        Console.WriteLine("Hello again team! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();
        
        Console.WriteLine("\nEnter a list of numbers, type 0 when finished.");
        
        Console.Write("\nEnter a number: ");
        int userNumber = int.Parse(Console.ReadLine());

        
        while (userNumber != 0)
        {
            numbers.Add(userNumber);

            Console.Write("Enter a number: ");
            userNumber = int.Parse(Console.ReadLine());
        }
            Console.WriteLine("_____________________________________");
        if (numbers.Count > 0)
        {
            //Core requirement 1: sum of the numbers in the list.
            int sum = 0;
            foreach (int n in numbers)
            {
                sum += n;
            }
            Console.WriteLine($"\nThe sum is: {sum}.");

            //Core requirement 2: average of the numbers in the list.
            
            /*Using “double” to declare the variable ‘average’ 
            and pairing it with the variable “sum” prevents C# 
            from converting all calculations to integers, 
            which allows the calculation to be performed 
            with decimals and stored with decimals.*/
            
            double average = (double)sum / numbers.Count;

            Console.WriteLine($"The average is: {average}.");

            //Core requirement 3: Higher number or the maximum value on the list.
            int largest = numbers[0];
            foreach (int n in numbers)
            {
                if (n > largest)
                {
                    largest = n;
                }
            }
            Console.WriteLine($"The largest number is: {largest}.");
            Console.WriteLine("_____________________________________");

            Console.WriteLine("\nNumbers in the list:");
            foreach (int n in numbers)
            {
                Console.WriteLine($"- {n}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("\nNo numbers were entered.");
        }
    }
}