namespace AppSharp_6;
class MyClass
{
    static void Calculator_GotResult(object sendler, EventArgs eventArgs)
    {
        Console.WriteLine($"{((Calculator)sendler).Result}");
    }
    static void Main(string[] args)
    {
        Calculator calc = new();

        calc.GotResult += Calculator_GotResult;

        bool flag = true;
        do
        {
            if (calc.Results.Count == 0)
            {
                Console.WriteLine("Введите число:");
                if (!Int32.TryParse(Console.ReadLine(), out int firstNum))
                {
                    Console.WriteLine("Число введено не корректно. Выполнение прекращено");
                    break;
                }
                calc.Result = firstNum;
            }

            Console.WriteLine("Выберите операцию + , - , * , / :");
            char op = Console.ReadKey().KeyChar;
            if (!"+-/*".Contains(op))
            {
                Console.WriteLine("Выполнение остановлено");
                break;
            }
            Console.WriteLine();

            Console.WriteLine("Введите число:");
            if (!Int32.TryParse(Console.ReadLine(), out int secondNum))
            {
                Console.WriteLine("Число введено не корректно. Выполнение прекращено"); ;
                break;
            }
            
            try
            {
                switch (op)
                {
                    case '+':
                        calc.Sum(secondNum);
                        break;
                    case '-':
                        calc.Substruct(secondNum);
                        break;
                    case '*':
                        calc.Multiplay(secondNum);
                        break;
                    case '/':
                        calc.Divide(secondNum);
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
            catch (CalculatorDivideByZeroExeption ex)
            {
                Console.WriteLine(ex);
            }
            catch (CalculateOperationCauseOverflowExeption ex)
            {
                Console.WriteLine(ex);
            }
        }
        while (flag);

    }

}
