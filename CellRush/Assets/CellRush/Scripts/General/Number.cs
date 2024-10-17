using JetBrains.Annotations;
using NUnit.Framework.Internal;
using Sirenix.OdinInspector;
using UnityEngine;
[System.Serializable]

public class Number
{
    private static readonly string[] suffixes = { "", "K", "M", "B", "T", "P", "E", "Z", "Y" };
    [OnValueChanged("UpdateValue")] public double mantissa; // The number between 1 and 999
    [OnValueChanged("UpdateValue")] public int magnitude;   // The index of the suffix

    [ReadOnly] public string value;
    public void UpdateValue() { value = ToString(); }



    public Number(double mantissa, int magnitude)
    {
        this.mantissa = mantissa;
        this.magnitude = magnitude;
    }

    public override string ToString()
    {
        return string.Format("{0:0.00}{1}", mantissa, suffixes[magnitude]);
    }


    public int CompareTo(Number other)
    {
        // Compare magnitudes first
        if (this.magnitude > other.magnitude) return 1;
        if (this.magnitude < other.magnitude) return -1;

        // If magnitudes are the same, compare mantissas
        return this.mantissa.CompareTo(other.mantissa);
    }

    public bool IsGreaterThan(Number other)
    {
        return CompareTo(other) > 0;
    }

    public static Number operator *(Number a, float b)
    {
        double result = a.mantissa * b;
        int newMagnitude = a.magnitude;

        while (result >= 1000)
        {
            result /= 1000;
            newMagnitude++;
        }

        while (result < 1 && newMagnitude > 0)
        {
            result *= 1000;
            newMagnitude--;
        }

        return new Number(result, newMagnitude);
    }
     public static Number operator *(Number a, int b)
    {
        return a * (float)b;
    }
    public static Number operator *(float a, Number b)
    {
        return b * a;
    }
    public static Number operator *(int a, Number b)
    {
        return b * a;
    }

}
