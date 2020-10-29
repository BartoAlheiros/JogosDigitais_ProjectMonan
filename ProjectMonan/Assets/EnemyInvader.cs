using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInvader : MonoBehaviour
{
    private bool grounded;

    public Transform groundCheck;

    public LayerMask groundLayer;

    public float speed;
    private Rigidbody2D rb;
    private float visionDistance; 

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);

        if(transform.position.x == 116.3 || transform.position.x == 147.56)
            Flip();
    }

    private void FixedUpdate() {
        rb.velocity = Vector2.right * speed;
    }

    void Flip() {
        speed *= -1;
        Vector3 theScale = transform.localScale;
        theScale *= -1;
        transform.localScale = theScale;
    }
}
