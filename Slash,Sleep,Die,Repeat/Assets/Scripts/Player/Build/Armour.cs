using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Armour : MonoBehaviour
{
	public enum Type
	{
		robe,
		trollHide,
		dragonScale
	}
	[SerializeField]Type type;
	public Type GetType() { return type; }
	//These are how the armours affect the player
	public int HealthMod()
	{
		switch (type)
		{
			case Type.robe:
				return +0;
			case Type.trollHide:
				return +200;
			case Type.dragonScale:
				return +300;
		}
		return 0;
	}
	public int MovespeedMod()
	{
		switch (type)
		{
			case Type.robe:
				return +300;
			case Type.trollHide:
				return 0;
			case Type.dragonScale:
				return -100;
		}
		return 0;
	}
}