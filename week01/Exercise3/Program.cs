using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello partners! This is the Exercise3 Project.");

        string playAgain;

        do
        {
            ///additional line to separate responses and results and keep visual order.
            Console.WriteLine("______________________________________________");
            
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);
            
            //int magicNumber;
            int guess = 0;
            
            ///STRETCH CHALLENGE, count for each try to guess, variable definition.
            int guessCount = 0;
            
            //Console.Write("What is the magic number?");
            //magicNumber = int.Parse(Console.ReadLine());
            //while (guess != magicNumber)
            
            while (guess != number)
            {
                Console.WriteLine("Try to guess a number between 1 and 100.");
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                
                ///STRETCH CHALLENGE, counter for eact try.
                guessCount++;
                
                //if (guess < magicNumber)
                if (guess < number)
                {
                    Console.WriteLine("Higher.");
                }
                //else if (guess > magicNumber)
                else if (guess > number)
                {
                    Console.WriteLine("Lower.");
                }
                else
                {
                    Console.WriteLine($"You guessed in {guessCount} guesses.");
                }
                
                ///additional line to separate responses and results and keep visual order.
                Console.WriteLine("______________________________________________");
            }

            Console.Write("\nDo you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();

        } while (playAgain.ToLower() == "yes");    

        Console.WriteLine("\nThanks for playing, see you later.");    
    }
}