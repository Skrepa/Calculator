using System;
namespace Calculator
{
    public class Calculator
    {
        private readonly ExpressionParser _parser;

        public Calculator(ExpressionParser parser)
        {
            _parser = parser;
        }

        public double Calculate(string expression)
        {
            return _parser.Parse(expression);
        }
    }
}

