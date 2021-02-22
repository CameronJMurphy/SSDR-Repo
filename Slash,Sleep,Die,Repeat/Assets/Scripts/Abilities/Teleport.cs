using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public void Cast()
	{
		Vector3 mousePos = Player.instance.PlayerToMouse();
		mousePos.z = 0;
		Player.instance.transform.position = mousePos;
	}
}
