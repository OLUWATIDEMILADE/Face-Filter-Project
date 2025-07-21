using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio References")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string backgroundMusicParameter = "BackgroundMusic";

    [Header("UI References")]
    [SerializeField] private Slider backgroundMusicSlider;
    [SerializeField] private Toggle muteToggle;

    private bool isMuted = false;
    private float preMuteVolume = 0.75f;

    private void Awake()
    {
        // Load saved settings
        float savedVolume = PlayerPrefs.GetFloat("BackgroundMusicVolume", 0.75f);
        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1;

        // Apply volume
        SetBackgroundMusicVolume(savedVolume);
        if (backgroundMusicSlider != null)
        {
            backgroundMusicSlider.value = savedVolume;
            backgroundMusicSlider.onValueChanged.AddListener(SetBackgroundMusicVolume);
        }

        // Apply mute state
        if (muteToggle != null)
        {
            muteToggle.isOn = isMuted;
            muteToggle.onValueChanged.AddListener(ToggleMute);
        }

        if (isMuted)
        {
            preMuteVolume = savedVolume;
            audioMixer.SetFloat(backgroundMusicParameter, -80f);
        }
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        if (isMuted) return;

        float dB = volume > 0 ? 20f * Mathf.Log10(volume) : -80f;
        audioMixer.SetFloat(backgroundMusicParameter, dB);
        PlayerPrefs.SetFloat("BackgroundMusicVolume", volume);
    }

    public void ToggleMute(bool mute)
    {
        isMuted = mute;
        PlayerPrefs.SetInt("IsMuted", mute ? 1 : 0);

        if (mute)
        {
            // Store current volume before muting
            preMuteVolume = backgroundMusicSlider != null ? backgroundMusicSlider.value : 0.75f;
            audioMixer.SetFloat(backgroundMusicParameter, -80f);
        }
        else
        {
            // Restore previous volume
            SetBackgroundMusicVolume(preMuteVolume);
            if (backgroundMusicSlider != null)
            {
                backgroundMusicSlider.value = preMuteVolume;
            }
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
