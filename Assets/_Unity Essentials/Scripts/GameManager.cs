using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip victorySound;

    void Start()
    {
        Collectible2D.allCollectedSound = victorySound;
    }
}
