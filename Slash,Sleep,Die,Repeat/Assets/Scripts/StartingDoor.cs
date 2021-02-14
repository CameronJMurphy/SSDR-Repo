using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDoor : MonoBehaviour
{
	[SerializeField] BoxCollider2D collisionBox;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(Player.instance.GetStats().ApplyBuild())
		{
			collisionBox.isTrigger = true;
		}
		else //make sure the player isnt leaving the starting room without a full build
		{
			collisionBox.isTrigger = false;
		}

	}
}
