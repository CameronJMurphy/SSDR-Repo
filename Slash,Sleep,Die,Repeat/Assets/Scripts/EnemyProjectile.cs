using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	[SerializeField] int damage;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<Player>() != null)
		{
			collision.gameObject.GetComponent<Player>().TakeDamage(damage);
		}
		if (collision.gameObject.GetComponent<Enemy>() == null
			&& collision.gameObject.GetComponent<EnemyProjectile>() == null
			&& collision.gameObject.tag != "Barrier"
			&& collision.gameObject.tag != "Zone"
			&& collision.gameObject.tag != "Weapon")
		{
			Destroy(gameObject);
		}
	}
}
