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
	public int GetTimer() { return (int)timer; }
	public float GetCooldown() { return cooldown; }
	public void ModifyCooldownMax(float amount)
	{
		cooldown += amount;
	}

	private void Start()
	{
		ResetSpellValues();
	}

	public void ResetSpellValues()
	{
		switch (type)
		{
			case Type.fireball:
				damage = 30;
				cooldown = 10;
				break;
			case Type.teleport:
				damage = 0;
				cooldown = 12;
				break;
			case Type.shield:
				damage = 0;
				cooldown = 17;
				break;
		}
	}
	private void Update()
	{
		timer -= Time.deltaTime;
		PlayerUI.instance.UpdatePlayerCooldownText();
	}

	public bool Cast()
	{
		if (timer < 0)
		{
			switch (type)
			{
				case Type.fireball:
					timer = cooldown;
					FindObjectOfType<Fireball>().Cast();
					return true;
				case Type.teleport:
					FindObjectOfType<Teleport>().Cast();
					timer = cooldown;
					return true;					
				case Type.shield:
					timer = cooldown;
					FindObjectOfType<Shield>().Cast();
					return true;
			}
		}
		return false;
	}
}
