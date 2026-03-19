using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float currentTime = 0;
    
    private bool isRunning = false;
    
    public Rigidbody playerRB;

    public TextMeshProUGUI bestTimeText;

    void Start()
    {
        DisplayBestTime();
    }
    void Update()
    {
        if (!isRunning && playerRB.linearVelocity.magnitude > 0.1f)
        {
            isRunning = true; // start once
        }

        if (isRunning)
        {
            currentTime += Time.deltaTime;
            UpdateTimerDisplay(currentTime);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ResetBestTime();
        }
    }


    void UpdateTimerDisplay(float timeInSeconds)
    {
        int minutes = (int)(timeInSeconds / 60);
        int seconds = (int)(timeInSeconds % 60);
        int milliseconds = (int)((timeInSeconds * 100) % 100);

        timerText.text = $"{minutes:00}:{seconds:00}.{milliseconds:00}";
    }
    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = 0;
        UpdateTimerDisplay(currentTime);
        isRunning = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveBestTime()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);

        if (currentTime < bestTime) 
        {
            PlayerPrefs.SetFloat("BestTime", currentTime);
            PlayerPrefs.Save();
        }
    }
    void DisplayBestTime()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0);

        if (bestTime == float.MaxValue || bestTime == 0)
        {
            bestTimeText.text = "Best: --:--";
            return;
        }

        int minutes = (int)(bestTime / 60);
        int seconds = (int)(bestTime % 60);
        int milliseconds = (int)((bestTime * 100) % 100);

        bestTimeText.text = $"Best: {minutes:00}:{seconds:00}.{milliseconds:00}";
    }
    public void ResetBestTime()
    {
        PlayerPrefs.DeleteKey("BestTime");
        DisplayBestTime();
    }

}
