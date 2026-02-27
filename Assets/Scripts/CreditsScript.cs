using UnityEngine;
using UnityEngine.InputSystem;

public class CreditsScript : MonoBehaviour
{
    public GameObject CreditsUI;

    public GameObject CreditsButton;

    public static bool CreditsScreenUp = false;

    // Update is called once per frame
    void Update()
    {


        if (CreditsButton.current.leftButton.wasPressedThisFrame)
        {
            if (CreditsScreenUp)
            {
                Resume();
            }
            else
            {
                Close();
            }
        }
    }

    void Resume()
    {
        CreditsUI.SetActive(false);
    }
}
