using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ResolutionSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        // Custom resolutions
        List<Vector2Int> customResolutions = new List<Vector2Int>()
        {
            new Vector2Int(1920, 1080),
            new Vector2Int(1600, 900),
            new Vector2Int(1280, 720),
            new Vector2Int(800, 600)
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

            // Check if this matches current resolution
            if (res.width == Screen.currentResolution.width &&
                res.height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);

        // Load saved settings if they exist
        int savedResolution = PlayerPrefs.GetInt("ResolutionIndex", currentResolutionIndex);
        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", Screen.fullScreen ? 1 : 0) == 1;

        // Apply saved settings
        resolutionDropdown.value = savedResolution;
        resolutionDropdown.RefreshShownValue();
        Screen.SetResolution(resolutions[savedResolution].width, resolutions[savedResolution].height, savedFullscreen);
        Screen.fullScreen = savedFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);

        // Save choice
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        PlayerPrefs.Save(); // make sure it writes to disk
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        // Save choice
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }
}