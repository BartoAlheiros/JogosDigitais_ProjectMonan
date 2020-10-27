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

	public PlayerInput input;

	private void Awake() {
		anim = GetComponent<PlayerAnimation>();
		input = GetComponent<PlayerInput>();
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
		IsDying();
    }

	public void IsDying() {
		if(currentHealth < 1){
			StartCoroutine(Dying());
		}
		
	}

	IEnumerator Dying() {
		input.enabled = false;
		anim.Die();
		yield return new WaitForSeconds(3);
		Time.timeScale = 0f;
		gameOverUi.SetActive(true);
	}
}
