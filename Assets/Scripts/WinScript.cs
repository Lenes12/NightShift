using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject WinScreenUI;
    public static bool  WinScreenPop = false; 

    // Update is called once per frame
    void Update()
    {
        {
            if (WinScreenPop)
            {
                Dormant ();
            }
            else 
            {
                Active();
            }
        }
    }
    public void NextLevel() 
    {
        Debug.Log("In Progress :p");
        Time.timeScale = 1f;  
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void Dormant() 
    {
        WinScreenUI.SetActive(false);
        Time.timeScale = 1f; 
        WinScreenPop = false;
    }

    void Active()
    { 
        WinScreenUI.SetActive(true);
        Time.timeScale = 0f;
        WinScreenPop = true;
    }
}
