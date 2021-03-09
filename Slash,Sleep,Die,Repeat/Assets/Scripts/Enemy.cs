using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int health;
	Animator aniCon;
	float cooldown = 0.5f;
	float timer = 0;

	private void Start()
	{
		aniCon = GetComponent<Animator>();
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
		aniCon.SetBool("Hit", true);
		CheckDeath();
	}

    void CheckDeath()
	{
        if(health < 1)
		{
			Win.instance.IncrementKillCount();
            Destroy(gameObject);
		}
	}

	private void Update()
	{
		if(aniCon.GetBool("Hit") == true)
		{
			timer += Time.deltaTime;
			if(timer > cooldown)
			{
				timer = 0;
				aniCon.SetBool("Hit", false);
			}
		}
	}
}
