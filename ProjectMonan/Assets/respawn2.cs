using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn2 : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter2D(Collider2D col)
    {
        player.transform.position = new Vector3(189, 18, 0);
        player.GetComponent<PlayerHealth>().TakeDamage(10);
    }

}
