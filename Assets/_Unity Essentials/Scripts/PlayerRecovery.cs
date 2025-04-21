using UnityEngine;

public class PlayerRecovery : MonoBehaviour
{
    public float checkInterval = 0.5f;
    public float tiltThreshold = -0.5f;
    public Vector3 defaultPosition; // Henüz hiç collectible alınmadıysa

    void Start()
    {
        InvokeRepeating(nameof(CheckIfFlipped), 0f, checkInterval);
    }

    void CheckIfFlipped()
    {
        if (transform.up.y < tiltThreshold)
        {
            Debug.Log("Player flipped!");

            Vector3 targetPos = Collectible.lastCollectedPosition;

            // Eğer hiç collectible toplanmadıysa default konuma ışınla
            if (targetPos == Vector3.zero)
                targetPos = defaultPosition;

            transform.position = targetPos;
            transform.rotation = Quaternion.identity; // Rotasyonu düzle
        }
    }
}
