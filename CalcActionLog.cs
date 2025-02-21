namespace AppSharp_6;

internal class CalcActionLog
{
    public CalcAction CalcAction {get; private set;}
    public int CalcArgument {get; private set;}
    public CalcActionLog(CalcAction calcAction, int calcArgument)
    {
        CalcAction = calcAction;
        CalcArgument = calcArgument;
    }
}