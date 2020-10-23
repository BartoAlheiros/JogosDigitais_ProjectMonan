using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnivorous_plant : MonoBehaviour
{   
    [Header("Ataque")]
    public float attackRate;
    public float attackDistance;
    public float nextAttack;
    private Transform player;


    private Rigidbody2D rb;
    private Animator anim;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();
    }

    void CheckTarget() {
        float distance = Vector2.Distance(transform.position, player.position);
        /*Calcula a direção. Se o resultado for positivo, o Player está à direita
        Se for negativo, o Player está à esquerda.*/
        float dir = player.transform.position.x - transform.position.x;

        if(distance < attackDistance) 
        {
            if(Time.time > nextAttack) 
            {
                if(dir > 0) {
                    nextAttack = Time.time + attackRate;
                    anim.SetTrigger("AttackLeft");

                } else if(dir < 0) {
                    nextAttack = Time.time + attackRate;
                    anim.SetTrigger("AttackRight");
                }
            }     
        }
    }
}
