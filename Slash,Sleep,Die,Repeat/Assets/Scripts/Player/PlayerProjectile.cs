using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Enemy>() != null)
		{
			collision.gameObject.GetComponent<Enemy>().TakeDamage(Player.instance.GetBuild().GetWeapon().GetDamage());
		}
		Destroy(gameObject);
	}
}
