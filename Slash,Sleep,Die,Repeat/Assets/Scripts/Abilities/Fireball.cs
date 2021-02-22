using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
	[SerializeField] GameObject fireball;
	[SerializeField] float force;
	
	public void Cast()
	{
		Player player = Player.instance;
		//instantiate
		GameObject fb = Instantiate(fireball, player.transform.position, player.transform.rotation);

		Vector3 mousePos = player.PlayerToMouse(); 
		
		Vector3 directionVec = mousePos - player.transform.position;
		directionVec.Normalize();

		//apply force to fireball
		fb.GetComponent<Rigidbody2D>().AddForce(directionVec * force);
	}
}
