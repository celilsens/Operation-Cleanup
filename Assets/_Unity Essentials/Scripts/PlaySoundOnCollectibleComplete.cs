using UnityEngine;
using System;

public class PlaySoundOnCollectibleComplete : MonoBehaviour
{
    public AudioClip completeSound;
    public GameObject finalEffectPrefab; // 👈 Son collectible için farklı efekt
    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing!");
        }
    }

    void Update()
    {
        if (hasPlayed || audioSource == null) return;

        int remainingCollectibles = 0;

        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            remainingCollectibles += UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
        }

        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            remainingCollectibles += UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }

        if (remainingCollectibles == 0)
        {
            audioSource.PlayOneShot(completeSound);
            hasPlayed = true;

            // 👇 Son alınan collectible'ın pozisyonuna özel efekt göster
            if (Collectible.lastCollected != null && finalEffectPrefab != null)
            {
                Instantiate(
                    finalEffectPrefab,
                    Collectible.lastCollected.transform.position,
                    Quaternion.identity
                );
            }
        }
    }
}
