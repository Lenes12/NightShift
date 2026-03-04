using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
       
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
}
