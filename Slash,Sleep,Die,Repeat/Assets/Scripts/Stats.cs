using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    int health;
    int movespeed;
    float magicCooldownMod;
    //Setters
    public void AddHealth(int amount) { health += amount; }
    public void MinusHealth(int amount) { health -= amount; }
    public void AddMovespeed(int amount) { movespeed += amount; }
    public void SetMagicCooldownMod(float amount) { magicCooldownMod = amount; }
    //Getters
    public int GetHealth() { return health; }
    public int GetMovespeed() { return movespeed; }
    public float GetMagicCooldownMod() { return magicCooldownMod; }

    public void ApplyBuild(Build build)
	{

	}
}
