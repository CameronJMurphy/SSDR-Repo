using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFirstRoom : MonoBehaviour
{
	[SerializeField] List<GameObject> startingRoomItems;
	Vector3 offscreen = new Vector3(10000,10000,0);
	// Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() != null)
		{
			foreach(var item in startingRoomItems)
			{
				item.transform.position = offscreen; //items have scripts on them that cannot be disabled
			}
		}
	}
}
