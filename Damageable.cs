using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent onDamage;
    public UnityEvent OnDeath;
    private bool isDead;
    public int maxHealth;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead)
            return;

        onDamage.Invoke();
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            //morte
            isDead = true;
            OnDeath.Invoke();
        }
    }
}
