using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Duration of a full day in seconds")]
    public float dayDurationInSeconds = 120f; // 2-minute default day length

    private float rotationSpeed;

    void Start()
    {
        // Calculate how many degrees per second (360 degrees in a full day)
        rotationSpeed = 360f / dayDurationInSeconds;
    }

    void Update()
    {
        // Rotate around the X axis to simulate sun movement
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
