using System;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello CSE210 Block 5! This is my Fractions Project.");

        Fraction call1 = new Fraction();
        Console.WriteLine(call1.GetFractionString());
        Console.WriteLine(call1.GetDecimalValue());

        Fraction call2 = new Fraction(5);
        Console.WriteLine(call2.GetFractionString());
        Console.WriteLine(call2.GetDecimalValue());

        Fraction call3 = new Fraction(8);
        Console.WriteLine(call3.GetFractionString());
        Console.WriteLine(call3.GetDecimalValue());

        Fraction call4 = new Fraction(3, 4);
        Console.WriteLine(call4.GetFractionString());
        Console.WriteLine(call4.GetDecimalValue());

        Fraction call5 = new Fraction(1, 3);
        Console.WriteLine(call5.GetFractionString());
        Console.WriteLine(call5.GetDecimalValue());

        Fraction call6 = new Fraction(5, 9);
        Console.WriteLine(call6.GetFractionString());
        Console.WriteLine(call6.GetDecimalValue());

        //Using the getters and setters.
        Fraction call7 = new Fraction();

        call7.SetTop(6);
        call7.SetBottom(3);

        Console.WriteLine(call7.GetTop());
        Console.WriteLine(call7.GetBottom());

        Console.WriteLine(call7.GetFractionString());
        Console.WriteLine(call7.GetDecimalValue());
    }
}