using System;
namespace Calculator.Operations
{
    public class Multiplication : IOperation
    {
        public double Evaluate(double left, double right) => left * right;
    }
}

