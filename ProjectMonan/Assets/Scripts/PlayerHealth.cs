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

	public AudioClip hitSfx;

	private SpriteRenderer sprite;

	private void Awake() {
		anim = GetComponent<PlayerAnimation>();
		input = GetComponent<PlayerInput>();
		audioManager = GetComponent<AudioManager>();
		sprite = GetComponent<SpriteRenderer>();
	}

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	public void TakeDamage(int damage, bool isEnemy)
	{
		int painSfx = Random.Range(0,10);
		painSfx = painSfx%3;
		
		if(currentHealth < 2*damage)
		{
			currentHealth -= damage;
			healthBar.SetHealth(currentHealth);
			Die();
		} else if(isEnemy && painSfx != 0) 
		{
			audioManager.PlayAudio(hitSfx);
			currentHealth -= damage;
			healthBar.SetHealth(currentHealth);
				
		} else if(isEnemy && painSfx == 0) 
		{
			currentHealth -= damage;
			healthBar.SetHealth(currentHealth);
		} else if(!isEnemy) {
			audioManager.PlayAudio(hitSfx);
			currentHealth -= damage;
			healthBar.SetHealth(currentHealth);
		}
		
	}

	   /* corrotina pra pintar o sprite do inimigo de vermelho,
    sinalizando que ele está sendo atingido pelo Player.*/
    IEnumerator Damage() {
        Color vermelho = new Color32(207, 40, 40, 255);
        sprite.color = vermelho;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
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
