using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class PlayerScript : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody rb;

    public TextMeshProUGUI score1Text;

    public TextMeshProUGUI score2Text;

    public ScoreManagerWin scoreManager;

    public ScoreManagerLose scoreManagerL;

    private Vector3 startPosition;

    private Quaternion startRotation;

    public RoadblockInScript blockUP;
    
    public AudioClip soundEffectClip;
  
    private AudioSource audioSource;

    public bool isTeleporting = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        scoreManager = FindFirstObjectByType<ScoreManagerWin>();

        scoreManagerL = FindFirstObjectByType<ScoreManagerLose>();
    }

     void FixedUpdate()
    {
        if (isTeleporting)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
      
        rb.linearVelocity = new Vector3(h * speed, v * speed, 0f);

    }

    void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void ResetPlayerToStart()
    {
        transform.position = startPosition;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Collectables")
        {
            scoreManager.CollectObject();
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Distract")
        {
            scoreManagerL.CollectObject();
            collision.gameObject.SetActive(false);

            ResetPlayerToStart();
        }
    }
}
