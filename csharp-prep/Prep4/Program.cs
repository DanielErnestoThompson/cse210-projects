using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        while (true)
        {
            Console.Write("Enter a number (0 to stop): ");
            int num = int.Parse(Console.ReadLine());
            if (num == 0)
            {
                break;
            }
            numbers.Add(num);
        }

        List<int> positives = numbers.Where(num => num > 0).ToList();
        int? closestToZero = positives.Any() ? positives.OrderBy(num => Math.Abs(num)).First() : null;

        List<int> sortedNumbers = numbers.OrderBy(num => num).ToList();

        Console.WriteLine("Numbers: " + string.Join(", ", numbers));
        Console.WriteLine("Total: " + numbers.Sum());
        Console.WriteLine("Average: " + numbers.Average());
        Console.WriteLine("Maximum: " + numbers.Max());
        Console.WriteLine("Closest to zero: " + closestToZero);
        Console.WriteLine("Sorted numbers: " + string.Join(", ", sortedNumbers));
    }
}
