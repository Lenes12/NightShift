using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
       
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

    
}
