using System;

class Program
{
    static void Main(string[] args)
    {
        // -- Parts 1 and 2 --
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());
        
        // --- Part 3 ---
        Random generator = new Random();
        
        string playAgain = "Y";
        
        while(playAgain == "Y")
        {
            int magicNumber = generator.Next(1, 100);
            int guessCount = 0;
            
            while (true)
            {
                Console.Write("What is your guess? ");
                int guessNumber = int.Parse(Console.ReadLine());
                guessCount++;

                if (guessNumber == magicNumber)
                    break;

                if (guessNumber > magicNumber)
                    Console.WriteLine("Lower");
                else
                    Console.WriteLine("Higher");
            }

            Console.WriteLine("You guessed it!!");
            Console.WriteLine("You did it in {0} guesses.", guessCount);

            Console.Write("\nDo you want to play again? (Y=yes, N=no) ");
            playAgain = Console.ReadLine();
        }
        
        Console.WriteLine("Thank you for playing!");
    }
}