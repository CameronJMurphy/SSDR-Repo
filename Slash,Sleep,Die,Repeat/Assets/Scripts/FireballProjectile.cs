using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
	AudioSource hitSFX;

	private void Start()
	{
		hitSFX = GameObject.FindGameObjectWithTag("FireballHit").GetComponent<AudioSource>(); //searchign by tag because this is on a prefab
	}
	//Deal damage when you hit an enemy
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<Enemy>() != null)
		{
			collision.gameObject.GetComponent<Enemy>().TakeDamage(Player.instance.GetBuild().GetSpell().GetDamage());			
		}
		//dont destroy the fireball if you hit the player, invisible barriers or your own weapon
		if(collision.gameObject.GetComponent<Player>() == null 
		&& collision.gameObject.GetComponent<EnemyProjectile>() == null
		&& collision.gameObject.GetComponent<PlayerProjectile>() == null
		&& collision.gameObject.tag != "Barrier" 
		&& collision.gameObject.tag != "Zone"
		&& collision.gameObject.tag != "Weapon")
		{
			Destroy(gameObject);
			hitSFX.Play();
		}		

	}
}
