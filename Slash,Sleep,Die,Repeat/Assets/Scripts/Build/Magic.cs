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
	float timer = 0;
	public Type GetType() { return type; }

	public int GetDamage() { return damage; }
	public int GetCooldown() { return (int)timer; }

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

	private void Update()
	{
		timer -= Time.deltaTime;
	}

	public bool Cast()
	{
		if (timer < 0)
		{
			switch (type)
			{
				case Type.fireball:
					timer = cooldown;
					return true;
				case Type.teleport:
					FindObjectOfType<Teleport>().Cast();
					timer = cooldown;
					return true;					
				case Type.shield:
					timer = cooldown;
					return true;
			}
		}
		return false;
	}
}
