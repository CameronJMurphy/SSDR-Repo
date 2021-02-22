using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour
{
	[SerializeField] float duration;
	public void Use()
	{
		GetComponent<Animator>().SetBool("Attack", true);
		StartCoroutine(Timer());
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds(duration);
		GetComponent<Animator>().SetBool("Attack", false);
	}
}
