using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour
{
	[SerializeField] float duration;
	[SerializeField] AudioSource SFX;

	bool attacking = false;
	PolygonCollider2D collider;
	private void Start()
	{
		collider = GetComponent<PolygonCollider2D>();
	}
	public void Use()
	{
		SFX.Play();
		GetComponent<Animator>().SetBool("Attack", true);
		//collider.isTrigger = false;
		attacking = true;
		StartCoroutine(Timer());
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds(duration);
		GetComponent<Animator>().SetBool("Attack", false);
		//collider.isTrigger = true;		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.GetComponent<Enemy>() != null)
		{
			int damage = Player.instance.GetBuild().GetWeapon().GetDamage();
			collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<Enemy>() != null && attacking == true)
		{
			int damage = Player.instance.GetBuild().GetWeapon().GetDamage();
			collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
			attacking = false;
		}
	}
}
