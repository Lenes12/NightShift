using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
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
