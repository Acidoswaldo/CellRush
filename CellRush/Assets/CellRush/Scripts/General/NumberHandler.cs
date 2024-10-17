using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class NumberHandler : MonoBehaviour
{

    public static Number Add(Number a, Number b)
    {
        // Ensure both numbers have the same magnitude for proper addition
        AlignMagnitudes(ref a, ref b);
        // Add the mantissas
        double resultMantissa = a.mantissa + b.mantissa;
        // Handle overflow beyond 999
        if (resultMantissa >= 1000)
        {
            resultMantissa /= 1000;
            a.magnitude++;
        }
        return new Number(resultMantissa, a.magnitude);
    }

    public static Number Multiply(Number a, double multiplier)
    {
        return MultiplyInternal(a, (double)multiplier);
    }

    public static Number Multiply(Number a, float multiplier)
    {
        return MultiplyInternal(a, (double)multiplier);
    }

    public static Number Multiply(Number a, int multiplier)
    {
        return MultiplyInternal(a, (double)multiplier);
    }

    public static Number Multiply(Number a, Number b)
    {
        double resultMantissa = a.mantissa * b.mantissa;
        int resultMagnitude = a.magnitude + b.magnitude;

        while (resultMantissa >= 1000)
        {
            resultMantissa /= 1000;
            resultMagnitude++;
        }

        return new Number(resultMantissa, resultMagnitude);
    }

    private static Number MultiplyInternal(Number a, double multiplier)
    {
        // Multiply mantissa by multiplier
        double resultMantissa = a.mantissa * multiplier;
        int resultMagnitude = a.magnitude;

        // Adjust magnitude if the mantissa goes beyond 999
        while (resultMantissa >= 1000)
        {
            resultMantissa /= 1000;
            resultMagnitude++;
        }

        return new Number(resultMantissa, resultMagnitude);
    }

    public static Number Divide(Number a, double divisor)
    {
        return DivideInternal(a, (double)divisor);
    }

    public static Number Divide(Number a, float divisor)
    {
        return DivideInternal(a, (double)divisor);
    }

    public static Number Divide(Number a, int divisor)
    {
        return DivideInternal(a, (double)divisor);
    }

    public static Number Divide(Number a, Number b)
    {
        double resultMantissa = a.mantissa / b.mantissa;
        int resultMagnitude = a.magnitude - b.magnitude;

        while (resultMantissa < 1 && resultMagnitude > 0)
        {
            resultMantissa *= 1000;
            resultMagnitude--;
        }

        return new Number(resultMantissa, resultMagnitude);
    }

    private static Number DivideInternal(Number a, double divisor)
    {
        // Divide mantissa by divisor
        double resultMantissa = a.mantissa / divisor;
        int resultMagnitude = a.magnitude;

        // Adjust magnitude if the mantissa goes below 1
        while (resultMantissa < 1 && resultMagnitude > 0)
        {
            resultMantissa *= 1000;
            resultMagnitude--;
        }

        return new Number(resultMantissa, resultMagnitude);
    }

    private static void AlignMagnitudes(ref Number a, ref Number b)
    {
        // Adjust the mantissa to align magnitudes
        while (a.magnitude > b.magnitude)
        {
            b.mantissa /= 1000;
            b.magnitude++;
        }
        while (b.magnitude > a.magnitude)
        {
            a.mantissa /= 1000;
            a.magnitude++;
        }
    }
}
