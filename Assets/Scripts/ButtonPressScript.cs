using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Button1PressScript : MonoBehaviour
  
{
    public GameObject GateObject;


    void Start()
    {

        if (GateObject != null)
        {
            GateObject.SetActive(true);

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
