using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ScoreManagerLose : MonoBehaviour
{
    public int totalLoss = 3;

    public int totalDistract;

    private int collectedCount = 0;

    public TextMeshProUGUI countText;

    public GameObject LoseScreenUI;

    public AudioClip soundEffectClip;

    private AudioSource audioSource;

    public TimeScript time;





    public void Start()
    {

        if (LoseScreenUI != null)
        {
            LoseScreenUI.SetActive(false);
        }

        audioSource = GetComponent<AudioSource>();

        UpdateCountText();
    }

    public void CollectObject()
    {
        collectedCount++;

        audioSource.PlayOneShot(soundEffectClip);

        UpdateCountText();

        if (collectedCount >= totalLoss)
        {
            LoseGame();
        }

    }

    void UpdateCountText()
    {
        if (countText != null)
        {
            countText.text = "Distractions: " + collectedCount.ToString() + "/" + totalLoss;
             
        }
        
    }

    void LoseGame()
    {
        if (LoseScreenUI != null)
        {
            LoseScreenUI.SetActive(true);

             
        }
        Time.timeScale = 0f; 

        time.StopTimer();
    }
}