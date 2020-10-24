using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public PlayerController playerController;

    public bool jumPressed;

    public bool attackPressed = false;

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

        attackPressed = Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.K);
        
    }

    private void FixedUpdate()
    {
        clearJump = true;
        playerController.Move(Input.GetAxisRaw("Horizontal"));
    }
}
