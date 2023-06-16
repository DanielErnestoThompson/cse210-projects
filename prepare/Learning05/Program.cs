using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        // Create square
        Square square = new Square("Red", 5.0);
        shapes.Add(square);

        // Create rectangle
        Rectangle rectangle = new Rectangle("Blue", 4.0, 6.0);
        shapes.Add(rectangle);

        // Create circle
        Circle circle = new Circle("Yellow", 3.0);
        shapes.Add(circle);

        // Display color and area of each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape color: {shape.Color}, Area: {shape.GetArea()}");
        }
    }
}
