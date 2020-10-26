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
    private bool onAttack;
    public int damage;
    public int health;


    private Rigidbody2D rb;
    private Animator anim;
    public PlayerHealth player_health;
    public SpriteRenderer sprite;

    float distance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        player_health = player.GetComponent<PlayerHealth>();
        sprite = GetComponent<SpriteRenderer>();
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

    void CheckTarget()
    {
        distance = Vector2.Distance(transform.position, player.position);
        /*Calcula a direção. Se o resultado for positivo, o Player está à direita
        Se for negativo, o Player está à esquerda.*/
        float dir = player.transform.position.x - transform.position.x;
        
        if (distance < attackDistance)
        {

            if (dir > 0)
            {
                if(Time.time > nextAttack)
                {
                    nextAttack = Time.time + attackRate;
                    onAttack = true;
                    anim.SetTrigger("AttackLeft");
                }
                

            }else if (dir < 0)
            {
                if(Time.time > nextAttack)
                {
                    nextAttack = Time.time + attackRate;
                    onAttack = true;
                    anim.SetTrigger("AttackRight");
                }
         
            }

        }else {
            onAttack = false;
        }
    }

    private void Attack() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(distance <= attackDistance) 
        {
            player_health.TakeDamage(damage);
        }
                
    }

    public void DamagePlant(int damage) {
        if(health < 1)
            return;
        StartCoroutine (Damage ());    
        health -= damage;
    }

    /* corrotina pra pintar o sprite do inimigo de vermelho,
    sinalizando que ele está sendo atingido pelo Player.*/
    IEnumerator Damage() {
        Color vermelho = new Color32(207, 40, 40, 255);
        sprite.color = vermelho;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
