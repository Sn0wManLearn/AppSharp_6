using System.Security.Cryptography.X509Certificates;

namespace AppSharp_6;

internal class Calculator : ICalc
{
    public event EventHandler<EventArgs> GotResult;

    public int Result = 0;

    public Stack<int> Results { get; private set; } = new Stack<int>();
    public Stack<CalcActionLog> actions = new Stack<CalcActionLog>();
    private void ShowAndSaveResult()
    {
        Results.Push(Result);
        RaiseEvent();
    }
    public void Sum(int value)
    {
        long temp = Result + value;
        if(temp > int.MaxValue)
        {
            actions.Push(new CalcActionLog(CalcAction.Sum, value));
            throw new CalculateOperationCauseOverflowExeption("Переполнение", actions);
        }
        Result += value;
        ShowAndSaveResult();
    }

    public void Substruct(int value)
    {
        int temp = int.MaxValue - Result - value;
        if(temp <= 0)
        {
            actions.Push(new CalcActionLog(CalcAction.Substruct, value));
            throw new CalculateOperationCauseOverflowExeption("Переполнение", actions);
        }
        Result -= value;
        ShowAndSaveResult();
    }

    public void Multiplay(int value)
    {
        long temp = Result * value;
        if(temp > int.MaxValue)
        {
            actions.Push(new CalcActionLog(CalcAction.Multiplay, value));
            throw new CalculateOperationCauseOverflowExeption("Переполнение", actions);
        }
        Result *= value;
        ShowAndSaveResult();
    }

    public void Divide(int value)
    {
        // В случае, если делить на дробное число меньше нуля, возможно переполнение
        if (value != 0)
        {
            Result /= value;
            ShowAndSaveResult();
        }
        else 
        {
            actions.Push(new CalcActionLog(CalcAction.Multiplay, value));
            throw new CalculatorDivideByZeroExeption("Нальзя делить на ноль!", actions);
        }
    }

    public void RaiseEvent()
    {
        GotResult?.Invoke(this, EventArgs.Empty);
    }

    public void CancelList()
    {
        if (Results.Count > 0)
        {
            Results.Pop();
            Result = Results.Pop();
            RaiseEvent();
        }
    }

}