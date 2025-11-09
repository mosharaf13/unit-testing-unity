using System;
using NUnit.Framework;

public class AdvancedCalculatorTests
{
    private AdvancedCalculator _calc;

    [SetUp]
    public void SetUp()
    {
        _calc = new AdvancedCalculator();
    }

    [Test]
    public void Power_PositiveExponent_WorksCorrectly()
    {
        float result = _calc.Power(2f, 3);
        Assert.AreEqual(8f, result);
    }

    [Test]
    public void Power_ZeroExponent_ReturnsOne()
    {
        float result = _calc.Power(5f, 0);
        Assert.AreEqual(1f, result);
    }

    [Test]
    public void Power_NegativeExponent_WorksCorrectly()
    {
        float result = _calc.Power(2f, -2);
        Assert.AreEqual(0.25f, result, 0.0001f);
    }

    [Test]
    public void Power_ZeroToNegative_Throws()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Power(0f, -1));
    }

    [Test]
    public void Average_MultipleValues_ReturnsCorrectAverage()
    {
        float result = _calc.Average(2f, 4f, 6f, 8f);
        Assert.AreEqual(5f, result);
    }

    [Test]
    public void Average_SingleValue_ReturnsSameValue()
    {
        float result = _calc.Average(10f);
        Assert.AreEqual(10f, result);
    }

    [Test]
    public void Average_NoValues_Throws()
    {
        Assert.Throws<ArgumentException>(() => _calc.Average());
    }

    [Test]
    public void Clamp_ValueBelowMin_ReturnsMin()
    {
        float result = _calc.Clamp(-5f, 0f, 10f);
        Assert.AreEqual(0f, result);
    }

    [Test]
    public void Clamp_ValueAboveMax_ReturnsMax()
    {
        float result = _calc.Clamp(15f, 0f, 10f);
        Assert.AreEqual(10f, result);
    }

    [Test]
    public void Clamp_ValueWithinRange_ReturnsValue()
    {
        float result = _calc.Clamp(5f, 0f, 10f);
        Assert.AreEqual(5f, result);
    }

    [Test]
    public void Clamp_MinGreaterThanMax_Throws()
    {
        Assert.Throws<ArgumentException>(() => _calc.Clamp(5f, 10f, 0f));
    }

    [Test]
    public void PercentageChange_Increase_ReturnsPositive()
    {
        float result = _calc.PercentageChange(100f, 120f);
        Assert.AreEqual(0.2f, result, 0.0001f); // 20%
    }

    [Test]
    public void PercentageChange_Decrease_ReturnsNegative()
    {
        float result = _calc.PercentageChange(100f, 80f);
        Assert.AreEqual(-0.2f, result, 0.0001f); // -20%
    }

    [Test]
    public void PercentageChange_FromZero_Throws()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.PercentageChange(0f, 50f));
    }
}
