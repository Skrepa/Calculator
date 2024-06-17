using System;
namespace Calculator.Operations
{
    public class Addition : IOperation
    {
        public double Evaluate(double left, double right) => left + right;
    }
}

