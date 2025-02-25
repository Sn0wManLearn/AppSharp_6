namespace AppSharp_6;
class MyClass
{
    static void Calculator_GotResult(object sender, EventArgs eventArgs)
    {
        Console.WriteLine($"{((Calculator)sender).Result}");
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
                if (!Double.TryParse(Console.ReadLine(), out double firstNum))
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
            if (!Double.TryParse(Console.ReadLine(), out double secondNum))
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
