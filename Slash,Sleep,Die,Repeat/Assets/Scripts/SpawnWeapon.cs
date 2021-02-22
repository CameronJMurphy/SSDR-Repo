using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
	[SerializeField] GameObject sword;
	[SerializeField] GameObject spear;
	[SerializeField] GameObject magicStaff;

	public void SpawnChosenWeapon(Weapon weapon)
	{
		//turn our weapon on and all other weapons off
		switch (weapon.GetType())
		{
			case Weapon.Type.sword:
				sword.SetActive(true);
				spear.SetActive(false);
				magicStaff.SetActive(false);
				break;
			case Weapon.Type.spear:
				sword.SetActive(false);
				spear.SetActive(true);
				magicStaff.SetActive(false);
				break;
			case Weapon.Type.magicStaff:
				sword.SetActive(false);
				spear.SetActive(false);
				magicStaff.SetActive(true);
				break;
		}
	}
}
