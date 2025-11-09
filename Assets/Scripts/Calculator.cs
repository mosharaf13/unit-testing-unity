using UnityEngine;

public class Calculator
{
    public float Add(float a, float b)
    {
        return a + b;
    }

    public float Subtract(float a, float b)
    {
        return a - b;
    }

    public float Multiply(float a, float b)
    {
        return a * b;
    }

    public float Divide(float a, float b)
    {
        if (b == 0f)
        {
            throw new System.DivideByZeroException();
        }

        return a / b;
    }
}

