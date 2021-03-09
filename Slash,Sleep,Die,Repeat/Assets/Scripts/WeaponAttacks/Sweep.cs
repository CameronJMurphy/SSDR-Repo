using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweep : MonoBehaviour
{
	[SerializeField] float duration;
	BoxCollider2D collider;
	private void Start()
	{
		collider = GetComponent<BoxCollider2D>();
	}
	public void Use()
	{
		GetComponent<Animator>().SetBool("Attack", true);
		collider.isTrigger = false;
		StartCoroutine(Timer());
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds(duration);
		GetComponent<Animator>().SetBool("Attack", false);
		collider.isTrigger = true; //so it doesnt collide into walls while walking around
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Enemy>() != null)
		{
			int damage = Player.instance.GetBuild().GetWeapon().GetDamage();
			collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
		}
	}
}
