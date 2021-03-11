using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	[SerializeField] AudioSource SFX;
    public void Cast()
	{
		SFX.Play();
		Vector3 mousePos = Player.instance.PlayerToMouse();
		mousePos.z = 0;
		Player.instance.transform.position = mousePos;
	}
}
