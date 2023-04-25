using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int input;
        do {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0) {
                numbers.Add(input);
    }
        } while (input != 0);
        
        int sum = 0;
        foreach (int number in numbers) {
            sum += number;
        }
        double average = (double)sum / numbers.Count;
        int max = numbers[0];
        foreach (int number in numbers) {
            if (number > max) {
                max = number;
            }
        }
        
        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + max);
    }
}