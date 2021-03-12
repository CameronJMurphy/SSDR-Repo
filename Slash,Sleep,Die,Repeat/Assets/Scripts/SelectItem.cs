using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
	SpawnWeapon spawnWeapon;
	SpawnArmour spawnArmour;
	SpawnArtifact spawnArtifact;
	SpawnMagic spawnMagic;
	[SerializeField] AudioSource pickUpSound;
	StartRoomUI startRoomUI;
	private void Start()
	{
		spawnWeapon = FindObjectOfType<SpawnWeapon>();
		spawnArmour = FindObjectOfType<SpawnArmour>();
		spawnArtifact = FindObjectOfType<SpawnArtifact>();
		spawnMagic = FindObjectOfType<SpawnMagic>();
		startRoomUI = FindObjectOfType<StartRoomUI>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			switch (gameObject.tag)
			{
				case "Weapon":
					Player.instance.GetBuild().SetWeapon(GetComponent<Weapon>());
					spawnWeapon.SpawnChosenWeapon(GetComponent<Weapon>());
					startRoomUI.DisplayWeaponText(true);
					break;
				case "Armour":
					Player.instance.GetBuild().SetArmour(GetComponent<Armour>());
					spawnArmour.Spawn();
					startRoomUI.DisplayArmourText(true);
					break;
				case "Magic":
					Player.instance.GetBuild().SetSpell(GetComponent<Magic>());
					spawnMagic.Spawn();
					startRoomUI.DisplayMagicText(true);
					break;
				case "Artifact":
					Player.instance.GetBuild().SetArtifact(GetComponent<Artifact>());
					spawnArtifact.Spawn();
					startRoomUI.DisplayArtifactText(true);
					break;
			}
			pickUpSound.Play();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			switch (gameObject.tag)
			{
				case "Weapon":
					startRoomUI.DisplayWeaponText(false);
					break;
				case "Armour":
					startRoomUI.DisplayArmourText(false);
					break;
				case "Magic":
					startRoomUI.DisplayMagicText(false);
					break;
				case "Artifact":
					startRoomUI.DisplayArtifactText(false);
					break;
			}
		}
	}


}
