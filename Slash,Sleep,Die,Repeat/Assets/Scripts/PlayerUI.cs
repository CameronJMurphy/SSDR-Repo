using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealthText;
	[SerializeField] TextMeshProUGUI playerCooldownText;
	public static PlayerUI instance;

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

	public void UpdatePlayerHealthText()
	{
		playerHealthText.text = "HP: " + Player.instance.GetStats().GetHealth().ToString();
	}

	public void UpdatePlayerCooldownText()
	{
		if (Player.instance.GetBuild().GetSpell() != null)
		{
			int cooldown;
			if(Player.instance.GetBuild().GetSpell().GetTimer() < 0) //make sure the displayed cooldown isn't in the negatives
			{
				cooldown = 0;
			}
			else
			{
				cooldown = Player.instance.GetBuild().GetSpell().GetTimer();
			}
			playerCooldownText.text = "Cooldown: " + cooldown.ToString();
		}
	}

}
