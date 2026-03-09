using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class RoadblockInScript : MonoBehaviour
{
    public GameObject roadBlockUI;


    public void Start()
    {
       
            roadBlockUI.SetActive(false);
     
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roadBlockUI.SetActive(true);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roadBlockUI.SetActive(false);
        }
    }
}


