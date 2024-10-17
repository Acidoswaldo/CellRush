using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PointGenerator))]
public class PointGenerator_Timer : MonoBehaviour
{
    [SerializeField] private float timerInterval = 1f; // Time interval in seconds
    private PointGenerator pointGenerator;
    bool initialized = false;

    private float timer = 0f;

    void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        // Ensure the PointGenerator component is assigned
        if (pointGenerator == null)
        {
            pointGenerator = GetComponent<PointGenerator>();
            if (pointGenerator == null)
            {
                Debug.LogError("PointGenerator component not found!");
                enabled = false; // Disable this script if PointGenerator is not found
                return;
            }
        }
        initialized = true;
    }

    private void Update()
    {
        if (!initialized) Initialize();
        timer += Time.deltaTime;

        if (timer >= timerInterval)
        {
            timer = 0f; // Reset the timer
            AddPoints();
        }
    }

    private void AddPoints()
    {
        pointGenerator.AddPoints();
    }
}
