using UnityEngine;
using UnityEngine.InputSystem;

public class WASDScript : MonoBehaviour
{
    private Vector3 PlayerPosition;

    [Header("Player Settings")]
    public float PlayerSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed == true)
        {
            PlayerPosition.y += PlayerSpeed / 95;
        }
        if (Keyboard.current.sKey.isPressed == true)
        {
            PlayerPosition.y -= PlayerSpeed / 95;
        }
        if (Keyboard.current.dKey.isPressed == true)
        {
            PlayerPosition.x += PlayerSpeed / 95;
        }
        if (Keyboard.current.aKey.isPressed == true)
        {
            PlayerPosition.x -= PlayerSpeed / 95;
        }
        if (Keyboard.current.upArrowKey.isPressed == true)
        {
            PlayerPosition.y += PlayerSpeed / 95;
        }
        if (Keyboard.current.downArrowKey.isPressed == true)
        {
            PlayerPosition.y -= PlayerSpeed / 95;
        }
        if (Keyboard.current.rightArrowKey.isPressed == true)
        {
            PlayerPosition.x += PlayerSpeed / 95;
        }
        if (Keyboard.current.leftArrowKey.isPressed == true)
        {
            PlayerPosition.x -= PlayerSpeed / 95;
        }
        this.transform.position = PlayerPosition;
    }
}
