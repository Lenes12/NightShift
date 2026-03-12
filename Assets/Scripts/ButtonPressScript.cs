using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class ButtonPressScript : MonoBehaviour
{
    public GameObject GateObject;
    
    public GameObject Button;

    public GameObject ButtonAlert;

    private bool playerNear = false;

    public AudioClip soundEffectClip;

    private AudioSource audioSource;

    public void Start()
    {
        if (GateObject != null)
        {
            GateObject.SetActive(true);
        }
        ButtonAlert.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {

            audioSource.PlayOneShot(soundEffectClip); 

            if (GateObject != null)
            {
                GateObject.SetActive(false);
                
                Destroy(Button, 0.5f);

                Destroy(ButtonAlert);

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            ButtonAlert.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            ButtonAlert.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (GateObject != null)
        {
            GateObject.SetActive(false);
        }
    }
}