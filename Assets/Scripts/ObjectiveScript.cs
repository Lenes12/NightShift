using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ObjectiveScript : MonoBehaviour
{
    public GameObject ObjectiveUI;

    public static bool ObjectiveScreenUp = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (ObjectiveScreenUp)
            {
                Resume();
            }
            else
            {
                Close();
            }
        }
    }

    void Resume ()
    {
        ObjectiveUI.SetActive(true);
        Time.timeScale = 0f;
        ObjectiveScreenUp=true;
    }
    public void Close()
    {
        ObjectiveUI.SetActive(false);
        Time.timeScale = 1f;
        ObjectiveScreenUp=false;
    }
}
