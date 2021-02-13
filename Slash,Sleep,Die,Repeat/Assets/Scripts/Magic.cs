using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
	public enum Type
	{
		fireball,
		teleport,
		shield
	}
	[SerializeField] Type type;
	int damage;
	float cooldown;
	public Type GetType() { return type; }

	public int GetDamage() { return damage; }
	public float GetCooldown() { return cooldown; }

	private void Start()
	{
		switch (type)
		{
			case Type.fireball:
				damage = 30;
				cooldown = 10;
				break;
			case Type.teleport:
				damage = 0;
				cooldown = 20;
				break;
			case Type.shield:
				damage = 0;
				cooldown = 30;
				break;
		}
	}
}
