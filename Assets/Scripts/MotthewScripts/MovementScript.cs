using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementScript : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody rb;
    public Vector3 movement;

   
    void Start()
    { 
        rb = this.GetComponent<Rigidbody>();
    }
  
    private void Update()
    {
        
        movement = new Vector3(Input.GetAxis("Horizontal"), 0 ,Input.GetAxis("Vertical"))* speed;
    }
    private void FixedUpdate()
    {
       rb.angularVelocity = (movement);
    
    }
}
