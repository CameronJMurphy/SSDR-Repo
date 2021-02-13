using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Armour : MonoBehaviour
{
	public enum Type
	{
		cloth,
		scalemail,
		platemail
	}
	[SerializeField]Type type;
	public Type GetType() { return type; }
	//These are how the armours affect the player
	public int HealthMod()
	{
		switch (type)
		{
			case Type.cloth:
				return -25;
			case Type.scalemail:
				return 50;
			case Type.platemail:
				return 100;
		}
		return 0;
	}
	public int MovespeedMod()
	{
		switch (type)
		{
			case Type.cloth:
				return 50;
			case Type.scalemail:
				return -25;
			case Type.platemail:
				return -50;
		}
		return 0;
	}
}