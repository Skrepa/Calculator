using System;
namespace Calculator.Operations
{
    public class Division : IOperation
    {
        public double Evaluate(double left, double right)
        {
            if (right == 0)
            {
                throw new DivideByZeroException("Делить на 0 не допустимо.");
            }
            return left / right;
        }
    }
}

