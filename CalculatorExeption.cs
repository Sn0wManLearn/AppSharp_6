namespace AppSharp_6;

internal class CalculatorExeption : Exception
{
    public CalculatorExeption(string v, Stack<CalcActionLog> actionLogs) : base(v)
    {
        ActionLogs = actionLogs;
    }
    public CalculatorExeption(string v, Exception ex) : base(v, ex)
    {

    }
    public override string ToString()
    {
        return Message + ": " + string.Join("\n", ActionLogs.Select(x => $"{x.CalcAction} {x.CalcArgument}"));
    }
    public Stack<CalcActionLog> ActionLogs { get; private set; }
}

internal class CalculatorDivideByZeroExeption : CalculatorExeption
{
    public CalculatorDivideByZeroExeption(string v, Stack<CalcActionLog> actionLogs) : base(v, actionLogs)
    {

    }

    public CalculatorDivideByZeroExeption(string v, Exception ex) : base(v, ex)
    {

    }
}

internal class CalculateOperationCauseOverflowExeption : CalculatorExeption
{
    public CalculateOperationCauseOverflowExeption(string v, Stack<CalcActionLog> actionLogs) : base(v, actionLogs)
    {

    }
    public CalculateOperationCauseOverflowExeption(string v, Exception ex) : base(v, ex)
    {

    }
}