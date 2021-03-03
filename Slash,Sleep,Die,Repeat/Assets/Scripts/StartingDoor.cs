using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDoor : MonoBehaviour
{
	[SerializeField] BoxCollider2D collisionBox;
	List<Animator> animations;

	private void Start()
	{
		animations = new List<Animator>(GetComponentsInChildren<Animator>());
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(Player.instance.GetStats().ApplyBuild())
		{
			collisionBox.isTrigger = true;
			foreach(var ani in animations)
			{
				ani.SetBool("Activate", true);
			}

		}
		else //make sure the player isnt leaving the starting room without a full build
		{
			collisionBox.isTrigger = false;
		}

	}
}
