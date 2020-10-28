using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth health;
    private int damage = 5;
    private bool isOnTrigger = false;

    private void Awake()
    {
        health = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isOnTrigger = true;
        if (health.currentHealth >= 2 * damage)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage, false);
        }
        else
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage, false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isOnTrigger = false;
    }


    void Update()
    {
        if (isOnTrigger == true)
        {
        }
    }

}
