using UnityEngine;

public class HorseSwing : MonoBehaviour
{
    public float swingAmplitude = 10f; // Sallanma açısı
    public float swingSpeed = 2f;      // Sallanma hızı

    private Vector3 initialRotation;

    void Start()
    {
        initialRotation = transform.localEulerAngles;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAmplitude;
        transform.localEulerAngles = new Vector3(initialRotation.x + angle, initialRotation.y, initialRotation.z);
    }
}
