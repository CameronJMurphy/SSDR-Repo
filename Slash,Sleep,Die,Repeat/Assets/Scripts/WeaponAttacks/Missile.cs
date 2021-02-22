using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
	[SerializeField] GameObject projectile;
	[SerializeField] float force;
	[SerializeField] float duration;
	public void Use()
	{
		GameObject proj = Instantiate(projectile, transform.position,transform.rotation);
		//find direction to fire
		Vector3 mousePos = Player.instance.PlayerToMouse();
		Vector3 directionVec = mousePos - transform.position;
		directionVec.Normalize();

		//apply force to fireball
		proj.GetComponent<Rigidbody2D>().AddForce(directionVec * force);

		GetComponent<Animator>().SetBool("Attack", true);
		StartCoroutine(Timer());
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds(duration);
		GetComponent<Animator>().SetBool("Attack", false);
	}

}
