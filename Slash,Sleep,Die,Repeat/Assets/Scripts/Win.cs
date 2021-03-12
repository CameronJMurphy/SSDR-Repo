using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Win : MonoBehaviour
{
	public Canvas winScreen;
	public TextMeshProUGUI kills;
	public TextMeshProUGUI Achievement;
	int killCount = 0;
	public static Win instance;
	int amountOfEnemies;

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
		amountOfEnemies = FindObjectsOfType<Enemy>().Length;
	}

	//pause game and brign up end screen canvas
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Time.timeScale = 0f;
		winScreen.gameObject.SetActive(true);
		kills.text = "Kills: " + killCount;
		if(killCount == 0)
		{
			Achievement.text = "Achievement: Pacifist";
		}
		else if (killCount < amountOfEnemies / 3)
		{
			Achievement.text = "Achievement: Coward";
		}
		else if (killCount < amountOfEnemies / 2.8)
		{
			Achievement.text = "Achievement: Weakling";
		}
		else if (killCount < amountOfEnemies / 2)
		{
			Achievement.text = "Achievement: Mediocre";
		}
		else if (killCount < amountOfEnemies / 1.8)
		{
			Achievement.text = "Achievement: Slayer";
		}
		else if (killCount < amountOfEnemies / 1.4)
		{
			Achievement.text = "Achievement: Godlike";
		}
		else if (killCount == amountOfEnemies)
		{
			Achievement.text = "Achievement: Genocide";
		}

	}

	public void IncrementKillCount()
	{
		++killCount;
	}
}
