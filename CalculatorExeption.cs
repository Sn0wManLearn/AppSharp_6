namespace AppSharp_6;

internal class CalculatorExeption : Exception
{
    public CalculatorExeption(string v) : base(v)
    {

    }
}

internal class CalculatorDivideByZeroExeption : CalculatorExeption
{
    public CalculatorDivideByZeroExeption(string v) : base(v)
    {

    }
}

internal class CalculateOperationCauseOverflowExeption : CalculatorExeption
{
    public CalculateOperationCauseOverflowExeption(string v) : base(v)
    {

    }
}