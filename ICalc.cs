using System.Data;

namespace AppSharp_6;

internal interface ICalc
{
    event EventHandler<EventArgs> GotResult;

    void Sum(double value);
    void Substruct(double value);
    void Multiplay(double value);
    void Divide(double value);
    void CancelList();
}