using System;
namespace Calculator.Operations
{
    public class Subtraction : IOperation
    {
        public double Evaluate(double left, double right) => left - right;
    }
}

