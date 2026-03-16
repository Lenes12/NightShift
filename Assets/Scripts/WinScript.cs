using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public AudioClip soundEffectClip;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
       
       audioSource.PlayOneShot(soundEffectClip);

        Time.timeScale = 0f;

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

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
