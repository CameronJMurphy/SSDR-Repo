using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI playerHealthText;
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

}
