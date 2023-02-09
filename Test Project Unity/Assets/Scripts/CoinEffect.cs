using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    public AudioSource audioPlayer;

    public void PlayAudio()
    {
        audioPlayer.Play();
    }
}
