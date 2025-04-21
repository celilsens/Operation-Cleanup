using UnityEngine;

public class BallCollisionSound : MonoBehaviour
{
    public AudioClip hitSound;     // Block'a çarpınca çalacak ses
    public AudioClip bounceSound;  // Diğer nesnelere çarpınca çalacak ses

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            audioSource.PlayOneShot(hitSound);
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
            audioSource.PlayOneShot(bounceSound);
        }
    }
}
