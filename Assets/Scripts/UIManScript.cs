using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject loseAlert;
    public float delayTime = 2f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        loseAlert.SetActive(false);
    }

    public void ShowLoseAlert()
    {
        StartCoroutine(LoseAlertRoutine());
    }

    IEnumerator LoseAlertRoutine()
    {
        loseAlert.SetActive(true);

        yield return new WaitForSeconds(delayTime);

        loseAlert.SetActive(false);
    }
}
