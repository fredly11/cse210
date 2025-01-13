using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            Console.WriteLine("Welcome to the Guess My Number game!");
            Console.WriteLine("I have selected a number between 1 and 100. Can you guess it?");
            
            int guess = 0;
            int attempts = 0;

            while (guess != magicNumber)
            {
                Console.Write("Enter your guess: ");
                
                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    attempts++;

                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it! The magic number was {magicNumber}.");
                        Console.WriteLine($"It took you {attempts} attempts.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            Console.Write("Would you like to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes");
        }

        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}
