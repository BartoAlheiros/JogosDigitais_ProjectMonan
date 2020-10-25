using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onça : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    bool facingRight = true;
    bool noChao = false;
    public Transform groundCheck;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("OnçaGroundChecker");
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (!noChao)
            speed *= -1;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (speed > 0 && !facingRight)
        {
            Flip();
        }
        else if (speed < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }
        }
    }
}
