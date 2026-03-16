using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioMixer audioMixer;

    void Awake()
    {
 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        float volume = PlayerPrefs.GetFloat("Volume", 1f);
        SetVolume(volume);
    }

    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);

        PlayerPrefs.SetFloat("Volume", volume);

        if (volume <= 0.0001f)
            audioMixer.SetFloat("Volume", -80f);
        else
            audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
}
