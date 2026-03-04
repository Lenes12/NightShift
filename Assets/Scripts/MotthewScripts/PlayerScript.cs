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

    public TextMeshProUGUI scoreText;

    public ScoreManagerWin scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreText.text = "Ingredients Collected: " + ScoreManagerWin.totalScore;
        scoreManager = FindFirstObjectByType<ScoreManagerWin>();

    }

     void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h,v,0.0f);
        transform.Translate(movement * speed * Time.deltaTime);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Collectables")
        {
            ScoreManagerWin.totalScore += 1;
            scoreManager.CollectObject();
            scoreText.text = "Ingredients Collected:  " + ScoreManagerWin.totalScore;
            collision.gameObject.SetActive(false);
        }
    }
}
