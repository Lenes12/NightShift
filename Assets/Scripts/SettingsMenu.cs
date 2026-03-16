using UnityEngine;
using UnityEngine.UI;

public class SettingsSlider : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = volume;
    }

    public void OnSliderChanged(float value)
    {
        AudioManager.Instance.SetVolume(value);
    }
}