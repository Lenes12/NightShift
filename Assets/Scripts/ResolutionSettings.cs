using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ResolutionSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        // Load fullscreen setting FIRST
        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", Screen.fullScreen ? 1 : 0) == 1;
        Screen.fullScreen = savedFullscreen;

        // Custom resolutions
        List<Vector2Int> customResolutions = new List<Vector2Int>()
        {
            new Vector2Int(1920, 1080),
            new Vector2Int(1600, 900),
            new Vector2Int(1280, 720),
            new Vector2Int(640, 360)
        };

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        resolutions = new Resolution[customResolutions.Count];
        int currentResolutionIndex = 0;

        for (int i = 0; i < customResolutions.Count; i++)
        {
            Resolution res = Screen.currentResolution;
            res.width = customResolutions[i].x;
            res.height = customResolutions[i].y;
            resolutions[i] = res;

            options.Add(res.width + " x " + res.height);

            if (res.width == Screen.currentResolution.width &&
                res.height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);

        // Load saved resolution
        int savedResolution = PlayerPrefs.GetInt("ResolutionIndex", currentResolutionIndex);

        resolutionDropdown.value = savedResolution;
        resolutionDropdown.RefreshShownValue();

        // Apply both settings together
        ApplyResolution(savedResolution, savedFullscreen);
    }

    public void SetResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        PlayerPrefs.Save();

        ApplyResolution(resolutionIndex, Screen.fullScreen);
    }

    public void ToggleFullscreen()
    {
        bool isFullscreen = !Screen.fullScreen;

        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();

        ApplyResolution(resolutionDropdown.value, isFullscreen);
    }

    void ApplyResolution(int resolutionIndex, bool isFullscreen)
    {
        Resolution res = resolutions[resolutionIndex];

        Screen.fullScreenMode = isFullscreen
            ? FullScreenMode.FullScreenWindow
            : FullScreenMode.Windowed;

        Screen.SetResolution(res.width, res.height, isFullscreen);
    }
}