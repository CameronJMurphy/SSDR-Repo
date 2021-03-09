﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
	SpawnWeapon spawnWeapon;
	SpawnArmour spawnArmour;
	SpawnArtifact spawnArtifact;
	private void Start()
	{
		spawnWeapon = FindObjectOfType<SpawnWeapon>();
		spawnArmour = FindObjectOfType<SpawnArmour>();
		spawnArtifact = FindObjectOfType<SpawnArtifact>();
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
					break;
				case "Armour":
					Player.instance.GetBuild().SetArmour(GetComponent<Armour>());
					spawnArmour.Spawn();
					break;
				case "Magic":
					Player.instance.GetBuild().SetSpell(GetComponent<Magic>());					
					break;
				case "Artifact":
					Player.instance.GetBuild().SetArtifact(GetComponent<Artifact>());
					spawnArtifact.Spawn();
					break;
			}
		}
	}

	
}
