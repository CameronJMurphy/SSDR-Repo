using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	
	public enum Type
	{
		sword,
		spear,
		magicStaff
	}
	[SerializeField]  Type type;
	int damage;
	float cooldown;
	float timer = 0;
	public Type GetType() { return type; }

	public int GetDamage() { return damage; }
	public float GetCooldown() { return cooldown; }
	//These are how the weapons affect the player
	public int HealthMod()
	{
		switch (type)
		{
			case Type.sword:
				return 50;
			case Type.spear:
				return 0;
			case Type.magicStaff:
				return -50;
		}
		return 0;
	}

	private void Start()
	{
		switch (type)
		{
			case Type.sword:
				damage = 10;
				cooldown = 0.1f;
				break;
			case Type.spear:
				damage = 8;
				cooldown = 0.3f;
				break;
			case Type.magicStaff:
				damage = 6;
				cooldown = 0.5f;
				break;
		}
	}

	private void Update()
	{
		timer -= Time.deltaTime;
	}
	public bool Attack()
	{
		if (timer < 0)
		{
			switch (type)
			{
				case Type.sword:
					timer = cooldown;
					FindObjectOfType<Sweep>().Use();
					return true;
				case Type.spear:
					FindObjectOfType<Stab>().Use(); timer = cooldown;
					return true;
				case Type.magicStaff:
					timer = cooldown;
					FindObjectOfType<Missile>().Use();
					return true;
			}
		}
		return false;
	}

}
