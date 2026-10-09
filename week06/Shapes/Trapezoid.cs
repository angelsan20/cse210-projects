public class Trapezoid : Shape
{
    private double _base1;
    private double _base2;
    private double _height;

    public Trapezoid(string color, double base1, double base2, double height) : base("Trapezoid", color)
    {
        _base1 = base1;
        _base2 = base2;
        _height = height;
    }

    public override double GetArea()
    {
        return ((_base1 + _base2) / 2.0) * _height;
    }
}