using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int health;
	[SerializeField] GameObject enemyProjectile;
	[SerializeField] float projectileSpeed;
	[SerializeField] float attackCooldown;
	float attackTimer = 0;

	AudioSource hurtAudio;
	Animator aniCon;
	float aniCooldown = 0.5f;
	float aniTimer = 0;

	

	private void Start()
	{
		aniCon = GetComponent<Animator>();
		hurtAudio = GameObject.FindGameObjectWithTag("EnemyHurtAudio").GetComponent<AudioSource>();
	}

	public void TakeDamage(int amount)
	{
		hurtAudio.Play();
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
			aniTimer += Time.deltaTime;
			if(aniTimer > aniCooldown)
			{
				aniTimer = 0;
				aniCon.SetBool("Hit", false);
			}
		}
		//attack the player when he is in your zone
		if (ZoneCon.instance.activeZone != null && ZoneCon.instance.activeZone.GetComponent<BoxCollider2D>().IsTouching(GetComponent<CircleCollider2D>()))
		{
			attackTimer += Time.deltaTime;
			if (attackTimer > attackCooldown)
			{
				attackTimer = 0;
				Attack();
			}
		}
	}

	void Attack()
	{
		GameObject proj = Instantiate(enemyProjectile,transform.position, transform.rotation);
		Vector3 direction = Player.instance.transform.position - transform.position;
		direction.Normalize();
		proj.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);
	}
}
