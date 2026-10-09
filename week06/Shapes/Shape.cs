using System;

public class Shape
{
    private string _color;
    private string _name;


    public Shape(string name, string color)
    {
        _name = name;
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    public string GetName()
    {
        return _name;
    }

    public virtual double GetArea()
    {
        return 0;
    }
}