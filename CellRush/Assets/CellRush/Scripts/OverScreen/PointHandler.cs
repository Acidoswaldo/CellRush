using UnityEngine;
using Sirenix.OdinInspector;

public class PointHandler : MonoBehaviour
{
    public Number points;
    public delegate void OnPointsChanged(Number newValue);
    public event OnPointsChanged onPointsChanged;

    void Start()
    {
        points = new Number(0, 0); // Initialize with 0
    }
    public void AddPoints(Number amount)
    {
        points = NumberHandler.Add(points, amount);
        onPointsChanged?.Invoke(points);
    }

    public void SubtractPoints(Number amount)
    {
        Number negativeAmount = new Number(-amount.mantissa, amount.magnitude);
        points = NumberHandler.Add(points, negativeAmount);
        onPointsChanged?.Invoke(points);
    }

    public void MultiplyPoints(double multiplier)
    {
        points = NumberHandler.Multiply(points, multiplier);
        onPointsChanged?.Invoke(points);
    }

    public void SetPoints(Number newValue)
    {
        points = newValue;
        onPointsChanged?.Invoke(points);
    }

    public Number GetPoints(){
        return points;
    }
}
