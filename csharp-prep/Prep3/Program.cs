using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 11);

        while (true)
        {
            Console.Write("Please guess the magic number: ");
            int guess = int.Parse(Console.ReadLine());

            if (guess == magicNumber)
            {
                Console.WriteLine("Congratulations! You guessed the magic number!");
                break;
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Guess higher next time.");
            }
            else
            {
                Console.WriteLine("Guess lower next time.");
            }
        }
    }
}
