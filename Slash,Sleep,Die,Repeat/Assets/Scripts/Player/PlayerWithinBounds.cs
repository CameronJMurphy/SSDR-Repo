using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWithinBounds : MonoBehaviour
{
	ReturnToMenu menuCon;
	private void Start()
	{
		menuCon = FindObjectOfType<ReturnToMenu>();
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.GetComponent<Player>() != null)
		{
			menuCon.ResetScene();
		}
	}
}
