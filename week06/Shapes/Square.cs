public class Square : Shape
{
    private double _side;

    public Square(string color, double side) : base("Square", color)
    {
        _side = side;
    }
    
    public override double GetArea()
    {
        return _side * _side;
    }
}