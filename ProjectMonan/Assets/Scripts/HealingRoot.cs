using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealingRoot : MonoBehaviour
{
    public bool isPressed;
    public GameObject keySprite;
    public int HealthPool = 50;
    public GameObject player;
    public GameObject animSprite;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (HealthPool > 0)
        {
            keySprite.active = true;
        }
    }


    void Update()
    {

        if (keySprite.active)
        {
            if (Input.GetButtonDown("Prompt"))
            {
                if (HealthPool > 0)
                {
                    if (player.GetComponent<PlayerHealth>().maxHealth > player.GetComponent<PlayerHealth>().currentHealth)
                    {
                        HealthPool -= 1;
                        player.GetComponent<PlayerHealth>().Heal(1);
                    }
                }
            }
        }
        if (HealthPool == 0)
        {
            animSprite.GetComponent<Animator>().Play("rootColor");
            keySprite.active = false;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        keySprite.active = false;
    }
}
