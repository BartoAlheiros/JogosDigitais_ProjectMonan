using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn2 : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth health;

    private void Awake() {
        health = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(health.currentHealth == 0)
            return;
        player.transform.position = new Vector3(189, 18, 0);
        player.GetComponent<PlayerHealth>().TakeDamage(20);
    }

}
