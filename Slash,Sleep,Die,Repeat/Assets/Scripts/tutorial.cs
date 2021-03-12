using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
	StartRoomUI startRoomUI;

	private void Start()
	{
		startRoomUI = FindObjectOfType<StartRoomUI>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		startRoomUI.DisplayTutorialText(true);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		startRoomUI.DisplayTutorialText(false);
	}
}
