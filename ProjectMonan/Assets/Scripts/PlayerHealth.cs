using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	public GameObject gameOverUi;
	public HealthBar healthBar;

	private PlayerAnimation anim;

	private PlayerInput input;

	private AudioManager audioManager;

	public AudioClip deathSfx;

	private void Awake() {
		anim = GetComponent<PlayerAnimation>();
		input = GetComponent<PlayerInput>();
		audioManager = GetComponent<AudioManager>();
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
		if(currentHealth < 1)
		{
			healthBar.SetHealth(currentHealth);
			Die();
		} else {
			healthBar.SetHealth(currentHealth);
		}
		
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
		
    }

	public void Die() {
		StartCoroutine(DieAux());
	}

	IEnumerator DieAux() {
		input.enabled = false;
		audioManager.PlayAudio(deathSfx);
		anim.Die();
		yield return new WaitForSeconds(3);
		Time.timeScale = 0f;
		gameOverUi.SetActive(true);
	}
}
