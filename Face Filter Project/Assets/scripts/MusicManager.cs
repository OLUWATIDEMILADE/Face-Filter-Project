using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMusic()
    {
        audioSource.mute = !audioSource.mute;
    }
}
