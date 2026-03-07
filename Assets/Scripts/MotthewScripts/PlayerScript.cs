using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        scoreManager = FindFirstObjectByType<ScoreManagerWin>();

        scoreManagerL = FindFirstObjectByType<ScoreManagerLose>();
    }

     void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h,v,0.0f);
        transform.Translate(movement * speed * Time.deltaTime);
        rb.AddForce(movement * speed);
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
