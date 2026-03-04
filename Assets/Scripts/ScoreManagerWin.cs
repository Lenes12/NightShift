using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ScoreManagerWin : MonoBehaviour
{
    public static int totalScore;

    public int totalCollectibles;
  
    private int collectedCount = 0;
    
    public TextMeshProUGUI countText;
    
    public GameObject WinScreenUI;



    public void Start()
    {
        if (WinScreenUI != null)
        {
            WinScreenUI.SetActive(false); 
            
        }
       
            UpdateCountText();
        
    }

    public void CollectObject()
    {
        collectedCount++;
       
       
        UpdateCountText();

        
        if (collectedCount >= totalCollectibles)
        {
            WinGame();

            
        }
    }

    void UpdateCountText()
    {
        if (countText !=null)
        {
            countText.text = "Ingredients Collected: " + collectedCount.ToString() + "/" + totalCollectibles.ToString();
        }
    }
    
  
    void WinGame()
    {
       

        if (WinScreenUI != null)
        {
            WinScreenUI.SetActive(true);
        }
        else
        {
            Debug.Log("WinScreenUI is NULL!");
        }

        Time.timeScale = 0f;
    }

}
