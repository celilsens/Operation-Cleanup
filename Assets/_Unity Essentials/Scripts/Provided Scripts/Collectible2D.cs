using System.Collections;
using UnityEngine;

public class Collectible2D : MonoBehaviour
{
    public float rotationSpeed = 0.5f;
    public GameObject onCollectEffect;
    public AudioClip collectSound;          // Her collectible için ses
    public static AudioClip allCollectedSound;  // Hepsi toplanınca çalınacak ses
    private static int totalCollectibles = 0;
    private static int collectedCount = 0;
    private static AudioSource audioSource;

    void Start()
    {
        totalCollectibles++;

        // Sadece ilk collectible objesinde ses kaynağını oluştur
        if (audioSource == null)
        {
            GameObject audioObj = new GameObject("CollectibleAudio");
            audioSource = audioObj.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController2D>() != null)
        {
            // Efekti oluştur
            if (onCollectEffect != null)
            {
                Instantiate(onCollectEffect, transform.position, transform.rotation);
            }

            // Toplama sesi çal
            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            collectedCount++;

            // Eğer tüm collectible'lar toplandıysa özel ses çal
            if (collectedCount >= totalCollectibles && allCollectedSound != null)
            {
                audioSource.PlayOneShot(allCollectedSound);
            }

            Destroy(gameObject);
        }
    }
}

