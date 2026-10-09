using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");


        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 4.0));
        shapes.Add(new Rectangle("Blue", 5.0, 3.0));
        shapes.Add(new Circle("Green", 2.5));
        shapes.Add(new Triangle("Yellow", 6.0, 4.0));
        shapes.Add(new Trapezoid("Purple", 3.0, 5.0, 4.0));

        foreach (Shape shape in shapes)
        {
            string name = shape.GetName();
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape is a {name} and has an area of: {area:F2}.");
        }
    }
}