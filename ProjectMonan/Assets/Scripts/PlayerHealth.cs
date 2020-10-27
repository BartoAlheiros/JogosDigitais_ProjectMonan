using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	public GameObject gameOverUi;
	public HealthBar healthBar;

	public PlayerAnimation anim;

	private void Awake() {
		anim = GetComponent<PlayerAnimation>();
	}

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if(currentHealth < 0)
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

	void Update()
    {
		if(currentHealth == 0)
        {
			StartCoroutine(Die());
			//Time.timeScale = 0f;
			gameOverUi.SetActive(true);
		}
    }

	IEnumerator Die() {
		anim.Die();
		yield return new WaitForSeconds(10);
	}
}
