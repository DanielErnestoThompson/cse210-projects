using System;

public class Fraction
{
    private int _numerator; // top number
    private int _denominator; // bottom number

    public Fraction() // Constructor that initializes to 1/1
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerator) // Constructor that initializes to numerator/1
    {
        _numerator = numerator;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator) // Constructor that initializes to numerator/denominator
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getters and Setters
    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; }
    }

    public int Denominator
    {
        get { return _denominator; }
        set { _denominator = value; }
    }

    // Method to get the fraction as a string
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Method to get the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
