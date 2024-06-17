namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new ExpressionParser();
            var calculator = new Calculator(parser);

            while(true)
            {
                Console.Write("Введите выражение: ");
                var input = Console.ReadLine();

                if(input!=null && input!="")
                {
                    try
                    {
                        var result = calculator.Calculate(input);
                        Console.WriteLine($"Результат: {result}\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}\n");
                    }
                }
                else { Console.WriteLine("Необходимо ввести выражение.\n"); }
                
            }
        }
    }
}

