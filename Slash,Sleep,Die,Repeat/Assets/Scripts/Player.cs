using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Stats stats;
    Build build;
	static public Player instance;
	[HideInInspector] public PlayerMovement playerMovement;
	[HideInInspector] public bool shielded = false;
	[SerializeField] int baseMoveSpeed;
	[SerializeField] int baseHealth;
	[SerializeField] int magicCDMod;
	[SerializeField] AudioSource hurtSFX;
	[SerializeField] AudioSource playerDeathMusic;
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
		stats = new Stats(baseHealth, baseMoveSpeed, magicCDMod);//base: health,movespeed and magicCooldownMod
		build = new Build();
		playerMovement = GetComponent<PlayerMovement>();
	}
	bool CastSpell()
	{
		if (build.GetSpell() != null)
		{
			if (build.GetSpell().Cast())
			{
				Debug.Log("Casting " + build.GetSpell().GetType());
				return true;
			}
			else
			{
				Debug.Log("Spell On Cooldown for " + build.GetSpell().GetTimer() + " seconds");
				return false;
			}
		}
		Debug.Log("Spell not selected");
		return false;	
		
	}
    bool Attack()
	{
		if (build.GetWeapon() != null)
		{
			if (build.GetWeapon().Attack())
			{
				Debug.Log("Attacking");
				return true;
			}
			else
			{
				Debug.Log("Attack on cooldown");
				return false;
			}
		}
		Debug.Log("Havent Selected weapon");
		return false;
	}

	public void TakeDamage(int amount)
	{
		if (!shielded)
		{
			hurtSFX.Play();
			GetStats().MinusHealth(amount);
			CheckDeath();
		}
		else //being shielded removes damage
		{

		}
	}

	void CheckDeath()
	{
		if(GetStats().GetHealth() < 1)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			playerDeathMusic.Play();
		}
	}
	public Stats GetStats() { return stats; }
	public Build GetBuild() { return build; }

	public Vector3 PlayerToMouse()
	{
		//find direction to fire
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = .5f;
		Ray ray = Camera.main.ScreenPointToRay(mousePos);
		Plane plane = new Plane(new Vector3(0, 0, -1), 0);
		float distance = 0;
		if (plane.Raycast(ray, out distance))
		{
			mousePos = ray.GetPoint(distance);
		}
		return mousePos;
	}

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
