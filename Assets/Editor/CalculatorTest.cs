using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CalculatorTest
{
    private Calculator _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_AddsTwoNumbers_ReturnsCorrectResult()
    {
        float result = _calculator.Add(2f, 3f);
        Assert.AreEqual(5f, result);
    }

    [Test]
    public void Subtract_SubtractsTwoNumbers_ReturnsCorrectResult()
    {
        float result = _calculator.Subtract(5f, 3f);
        Assert.AreEqual(2f, result);
    }

    [Test]
    public void Multiply_MultipliesTwoNumbers_ReturnsCorrectResult()
    {
        float result = _calculator.Multiply(2f, 3f);
        Assert.AreEqual(6f, result);
    }

    [Test]
    public void Divide_DividesTwoNumbers_ReturnsCorrectResult()
    {
        float result = _calculator.Divide(6f, 3f);
        Assert.AreEqual(2f, result);
    }

    [Test]
    public void Divide_DividesByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<System.DivideByZeroException>(() => _calculator.Divide(6f, 0f));
    }
}


