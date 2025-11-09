using System;
using UnityEngine;

public class AdvancedCalculator
{
    public float Power(float baseValue, int exponent)
    {
        if (exponent == 0) return 1f;

        float result = 1f;
        int absExp = Mathf.Abs(exponent);

        for (int i = 0; i < absExp; i++)
        {
            result *= baseValue;
        }

        if (exponent < 0)
        {
            if (result == 0f)
            {
                throw new DivideByZeroException("Cannot raise zero to a negative power.");
            }

            return 1f / result;
        }

        return result;
    }

    public float Average(params float[] values)
    {
        if (values == null || values.Length == 0)
        {
            throw new ArgumentException("At least one value is required.", nameof(values));
        }

        float sum = 0f;
        for (int i = 0; i < values.Length; i++)
        {
            sum += values[i];
        }

        return sum / values.Length;
    }

    public float Clamp(float value, float min, float max)
    {
        if (min > max)
        {
            throw new ArgumentException("Min cannot be greater than max.");
        }

        if (value < min) return min;
        if (value > max) return max;
        return value;
    }
    
    public float PercentageChange(float oldValue, float newValue)
    {
        if (Mathf.Approximately(oldValue, 0f))
        {
            throw new DivideByZeroException("Cannot compute percentage change from zero.");
        }

        return (newValue - oldValue) / oldValue;
    }
}