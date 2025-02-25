using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace AppSharp_6;

internal class Calculator : ICalc
{
    public event EventHandler<EventArgs> GotResult;

    public Double Result = 0;

    public Stack<double> Results { get; private set; } = new Stack<double>();
    public Stack<CalcActionLog> actions = new Stack<CalcActionLog>();
    private void SaveAndShowResult()
    {
        Results.Push(Result);
        RaiseEvent();
    }
    public void Sum(double value)
    {
        bool overFlow = double.MaxValue < Result + value;
        if (overFlow)
        {
            actions.Push(new CalcActionLog(CalcAction.Sum, value));
            throw new CalculateOperationCauseOverflowExeption("Переполнение", actions);
        }
        Result += value;
        SaveAndShowResult();
    }

    public void Substruct(double value)
    {
        bool overFlow = double.MinValue > Result - value;
        if (overFlow)
        {
            actions.Push(new CalcActionLog(CalcAction.Substruct, value));
            throw new CalculateOperationCauseOverflowExeption("Переполнение", actions);
        }
        Result -= value;
        SaveAndShowResult();
    }

    public void Multiplay(double value)
    {
        bool overFlow = double.MaxValue < Result * value;
        if (overFlow)
        {
            actions.Push(new CalcActionLog(CalcAction.Multiplay, value));
            throw new CalculateOperationCauseOverflowExeption("Переполнение", actions);
        }
        Result *= value;
        SaveAndShowResult();
    }

    public void Divide(double value)
    {
        // В случае, если делить на дробное число меньше нуля, возможно переполнение
        if (value != 0)
        {
            bool overFlow = double.MaxValue < Result / value;
            if (overFlow)
            {
                actions.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculateOperationCauseOverflowExeption("Переполнение", actions);
            }
            Result /= value;
            SaveAndShowResult();
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