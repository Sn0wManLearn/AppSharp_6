namespace AppSharp_6;

internal class CalculatorExeption : Exception
{
    public CalculatorExeption(string v) : base(v)
    {

    }
    public CalculatorExeption(string v, Exception ex) : base(v, ex)
    {

    }
}

internal class CalculatorDivideByZeroExeption : CalculatorExeption
{
    public CalculatorDivideByZeroExeption(string v) : base(v)
    {

    }

    public CalculatorDivideByZeroExeption(string v, Exception ex) : base(v, ex)
    {

    }
}

internal class CalculateOperationCauseOverflowExeption : CalculatorExeption
{
    public CalculateOperationCauseOverflowExeption(string v) : base(v)
    {

    }
    public CalculateOperationCauseOverflowExeption(string v, Exception ex) : base(v, ex)
    {

    }
}