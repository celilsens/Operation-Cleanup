using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectedSound;
    public float rotationSpeed;
    public GameObject onCollectEffect;

    public static Vector3 lastCollectedPosition;
    public static GameObject lastCollected;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lastCollectedPosition = transform.position;
            lastCollected = gameObject;

            if (onCollectEffect != null)
            {
                Instantiate(onCollectEffect, transform.position, transform.rotation);
            }

            if (collectedSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectedSound);
                // 🔄 Coroutine ile ses süresince bekle sonra yok et
                StartCoroutine(DestroyAfterSound(collectedSound.length));
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private System.Collections.IEnumerator DestroyAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
