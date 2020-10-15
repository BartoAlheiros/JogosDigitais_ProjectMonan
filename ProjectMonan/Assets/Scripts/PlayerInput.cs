using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public PlayerController playerController;

    public bool jumPressed;

    public bool clearJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
     if (clearJump) 
        {
            jumPressed = false;
        }

        clearJump = false;

        jumPressed = jumPressed || Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        clearJump = true;
        playerController.Move(Input.GetAxisRaw("Horizontal"));
    }
}
