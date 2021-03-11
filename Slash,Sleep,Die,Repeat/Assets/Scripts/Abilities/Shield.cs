using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
	[SerializeField] float duration;
	[SerializeField] GameObject shieldedEffect;
	[SerializeField] AudioSource SFX;
	public void Cast()
	{
		SFX.Play();
		Player.instance.shielded = true;
		shieldedEffect.SetActive(true);
		StartCoroutine(ShieldTimer());
	}
	IEnumerator ShieldTimer()
	{
		yield return new WaitForSeconds(duration);
		shieldedEffect.SetActive(false);
		Player.instance.shielded = false;
	}
}


