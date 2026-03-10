using UnityEngine;

public class LoseAlertTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowLoseAlert();

            Destroy(gameObject); 
        }
    }
}
