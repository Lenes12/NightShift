using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public GameObject LoseScreenUI;

    public static bool  LoseScreenPop = false;

    // Update is called once per frame
    void Update()
    {
        
        {
            if (LoseScreenPop)
            {
                Dormant();
            }
            else 
            {
                Active();
            }
        }
    }
    public void RestartCurrentLevel()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }

    public void Dormant() 
    {
        LoseScreenUI.SetActive(false);
        Time.timeScale = 1f;
        LoseScreenPop = false;
    }

    void Active() 
    {
        LoseScreenUI.SetActive(true);
        Time.timeScale = 0f;
        LoseScreenPop = true;
    }
}
