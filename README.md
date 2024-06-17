Консольный калькулятор, который принимает входную строку, содержащую математическое выражение (целые и десятично-дробные числа, знаки +, -, *, / и скобки) и 
выводит в консоль результат его вычисления.

xUnit тесты:
```C#

public class CalculatorTests
{
    private readonly Calculator.Calculator _calculator;

    public CalculatorTests()
    {
        var parser = new ExpressionParser();
        _calculator = new Calculator.Calculator(parser);
    }

    [Fact]
    public void TestAddition()
    {
        var result = _calculator.Calculate("1+2");
        Assert.Equal(3, result);
    }

    [Fact]
    public void TestSubtraction()
    {
        var result = _calculator.Calculate("5-3");
        Assert.Equal(2, result);
    }

    [Fact]
    public void TestMultiplication()
    {
        var result = _calculator.Calculate("4*2");
        Assert.Equal(8, result);
    }

    [Fact]
    public void TestDivision()
    {
        var result = _calculator.Calculate("6/2");
        Assert.Equal(3, result);
    }

    [Fact]
    public void TestComplexExpression()
    {
        var result = _calculator.Calculate("1+2*3-4/2");
        Assert.Equal(5, result);
    }

    [Fact]
    public void TestExpressionWithParentheses()
    {
        var result = _calculator.Calculate("((1+3)*(3-1))/8");
        Assert.Equal(1, result);
    }
}

```
<img width="731" alt="Снимок экрана 2024-06-17 в 22 46 24" src="https://github.com/Skrepa/Calculator/assets/23438074/eef7cbc6-eff2-44c0-835c-2082d0c7da5a">

