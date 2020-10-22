using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if(currentHealth > 0)
		{
			currentHealth = 0;
		}
		healthBar.SetHealth(currentHealth);
	}

	public void Heal(int amount)
	{
		currentHealth += amount;
		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
		healthBar.SetHealth(currentHealth);
	}

	public void IncreaseMaxHealth(int amount)
	{
		maxHealth += amount;
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}
}
