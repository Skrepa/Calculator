using System;
using System.Globalization;
using Calculator.Operations;

namespace Calculator
{
    public class ExpressionParser
    {
        private readonly Dictionary<string, IOperation> _operations;
        private readonly Dictionary<string, int> _precedence;

        public ExpressionParser()
        {
            _operations = new Dictionary<string, IOperation>
            {
                { "+", new Addition() },
                { "-", new Subtraction() },
                { "*", new Multiplication() },
                { "/", new Division() }
            };
            _precedence = new Dictionary<string, int>
            {
                { "+", 1 },
                { "-", 1 },
                { "*", 2 },
                { "/", 2 }
            };
        }

        public double Parse(string expression)
        {
            var output = new Queue<string>();
            var operators = new Stack<string>();
            var tokens = Tokenize(expression);

            foreach (var token in tokens)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                {
                    output.Enqueue(token);
                }
                else if (_operations.ContainsKey(token))
                {
                    while (operators.Count > 0 && _operations.ContainsKey(operators.Peek()) &&
                         _precedence[operators.Peek()] >= _precedence[token])
                    {
                        output.Enqueue(operators.Pop());
                    }
                    operators.Push(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        output.Enqueue(operators.Pop());
                    }
                    operators.Pop(); // remove "("
                }
            }

            while (operators.Count > 0)
            {
                output.Enqueue(operators.Pop());
            }

            return EvaluateRPN(output);
        }

        private List<string> Tokenize(string expression)
        {
            var tokens = new List<string>();
            var number = "";

            foreach (var ch in expression)
            {
                if (char.IsDigit(ch) || ch == '.')
                {
                    number += ch;
                }
                else
                {
                    if (!string.IsNullOrEmpty(number))
                    {
                        tokens.Add(number);
                        number = "";
                    }
                    tokens.Add(ch.ToString());
                }
            }

            if (!string.IsNullOrEmpty(number))
            {
                tokens.Add(number);
            }

            return tokens;
        }

        private double EvaluateRPN(Queue<string> tokens)
        {
            var stack = new Stack<double>();

            while (tokens.Count > 0)
            {
                var token = tokens.Dequeue();

                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
                {
                    stack.Push(number);
                }
                else if (_operations.ContainsKey(token))
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    var result = _operations[token].Evaluate(left, right);
                    stack.Push(result);
                }
            }

            return stack.Pop();
        }
    }
}