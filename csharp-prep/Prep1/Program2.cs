using System;

class Program {
    static void Main() {
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        string letter;
        if (grade >= 90) {
            letter = "A";
        } else if (grade >= 80) {
            letter = "B";
        } else if (grade >= 70) {
            letter = "C";
        } else if (grade >= 60) {
            letter = "D";
        } else {
            letter = "F";
        }

        string sign;
        int lastDigit = grade % 10;
        if (lastDigit >= 7 && letter != "F") {
            sign = "+";
        } else if (lastDigit < 3 && letter != "F") {
            sign = "-";
        } else {
            sign = "";
        }

        Console.WriteLine("Your letter grade is: " + letter + sign);

        if (grade >= 70) {
            Console.WriteLine("Congratulations, you passed the class!");
        } else {
            Console.WriteLine("Keep working hard and try again next time.");
        }
    }
}

