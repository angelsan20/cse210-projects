public class Triangle : Shape
{
    private double _base;
    private double _height;

    public Triangle(string color, double baseLength, double height) : base("Triangle", color)
    {
        _base = baseLength;
        _height = height;
    }

    public override double GetArea()
    {
        return (_base * _height) / 2.0;
    }
}