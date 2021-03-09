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
		else if (killCount < 5)
		{
			Achievement.text = "Achievement: Coward";
		}
		else if (killCount < 10)
		{
			Achievement.text = "Achievement: Weakling";
		}
		else if (killCount < 20)
		{
			Achievement.text = "Achievement: Mediocre";
		}
		else if (killCount < 30)
		{
			Achievement.text = "Achievement: Slayer";
		}
		else if (killCount < 38)
		{
			Achievement.text = "Achievement: Godlike";
		}
		else if (killCount == 38)
		{
			Achievement.text = "Achievement: Genocide";
		}

	}

	public void IncrementKillCount()
	{
		++killCount;
	}
}
