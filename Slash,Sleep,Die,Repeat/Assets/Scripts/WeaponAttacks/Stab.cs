﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour
{
	[SerializeField] AudioSource SFX;

	bool attacking = false;
	Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void Use()
	{
		SFX.Play();
		GetComponent<Animator>().SetTrigger("Attack");
		attacking = true;
	}

	private void Update()
	{
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("SpearAttack"))
		{
			attacking = false;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<Enemy>() != null && attacking == true)
		{
			int damage = Player.instance.GetBuild().GetWeapon().GetDamage();
			collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
			attacking = false;
		}
	}
}
