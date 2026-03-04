using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ScoreManagerLose : MonoBehaviour
{
    public int totalLoss = 3;

    public int totalDistract;

    private int collectedCount = 0;

    public TextMeshProUGUI countText;

    public GameObject LoseScreenUI;

    public void Start()
    {
        if ( LoseScreenUI != null )
        {
            LoseScreenUI.SetActive( false );
        }

        UpdateCountText();

    }

    public void CollectObject()
    {
        collectedCount++;

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
        else
        {
            Debug.Log("LoseScreenUI is NULL");
        }

        Time.timeScale = 0f;
    }
}
