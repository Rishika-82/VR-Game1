using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip successClip;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySuccess()
    {
        audioSource.PlayOneShot(successClip);
    }
}