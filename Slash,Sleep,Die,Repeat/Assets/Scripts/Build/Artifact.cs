using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Artifact : MonoBehaviour
{
	public enum Type
	{
		giant,
		prayerMantis,
		sage
	}
	[SerializeField]Type type;
	public Type GetType() { return type; }
	//These are how the Artifacts affect the player
	public int HealthMod()
	{
		switch (type)
		{
			case Type.giant:
				return 50;
			case Type.prayerMantis:
				return 0;
			case Type.sage:
				return 0;
		}
		return 0;
	}
	public int MovespeedMod()
	{
		switch (type)
		{
			case Type.giant:
				return 0;
			case Type.prayerMantis:
				return 100;
			case Type.sage:
				return 0;

		}
		return 0;
	}
	public float MagicCooldownMod()
	{
		switch (type)
		{
			case Type.giant:
				return 0;
			case Type.prayerMantis:
				return 0;
			case Type.sage:
				return -5;

		}
		return 0;
	}

	public float SizeMod()
	{
		switch (type)
		{
			case Type.giant:
				return 0.25f;
			case Type.prayerMantis:
				return -0.25f;
			case Type.sage:
				return 0;

		}
		return 0;
	}
}
