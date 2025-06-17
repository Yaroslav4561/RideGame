using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic;
    private AudioSource audioSource;
    private const string MusicPrefKey = "MusicEnabled";

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        bool enabled = PlayerPrefs.GetInt(MusicPrefKey, 1) == 1;
        if (enabled)
        {
            audioSource.Play();
        }
    }


    public void ToggleMusic()
    {
        bool isOn = PlayerPrefs.GetInt(MusicPrefKey, 1) == 1;

        if (isOn)
        {
            audioSource.Stop(); // ⛔ повністю зупиняємо музику
            PlayerPrefs.SetInt(MusicPrefKey, 0);
        }
        else
        {
            audioSource.Play(); // ▶️ вмикаємо музику знову
            PlayerPrefs.SetInt(MusicPrefKey, 1);
        }

        PlayerPrefs.Save();
    }

}
