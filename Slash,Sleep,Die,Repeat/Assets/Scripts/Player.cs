using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Stats stats;
    Build build;
	static public Player instance;
	public PlayerMovement playerMovement;
	//create singleton
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	private void Start()
	{
		stats = new Stats(200,150,0);//base: health,movespeed and magicCooldownMod
		build = new Build();
		playerMovement = GetComponent<PlayerMovement>();
	}
	bool CastSpell()
	{
		Debug.Log("Casting Spell");
        return true;
	}
    bool Attack()
	{
		Debug.Log("Attacking");
        return true;
	}

	public Stats GetStats() { return stats; }
	public Build GetBuild() { return build; }

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Attack();
		}
		if(Input.GetKeyDown(KeyCode.F))
		{
			CastSpell();
		}

	}
}
