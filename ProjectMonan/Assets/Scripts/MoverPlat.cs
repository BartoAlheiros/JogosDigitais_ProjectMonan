using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlat : MonoBehaviour {
	
	float dirX, moveSpeed = 3f;
	bool moveRight = true;

	void Update () {
		if (transform.position.x > 210)
			moveRight = false;
		if (transform.position.x < 197)
			moveRight = true;

		if (moveRight)
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
		else
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
	}

	/*Se o Player colidir com a plataforma móvel,
	ele se torna filho do Objeto Plataforma, e assim, se move junto com ela.*/	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			other.transform.SetParent(transform);
		}
	}

	/*Se sair da Plataforma, o GameObject dele passa para a raíz da cena novamente.*/	
	private void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			other.transform.SetParent(null);
		}
	}
}
