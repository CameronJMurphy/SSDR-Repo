using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public Stats(int h, int ms, float mod)
    {
        health = h;
        movespeed = ms;
        magicCooldownMod = mod;

        baseHealth = h;
        baseMovespeed = ms;
        baseMagicCooldownMod = mod;
    }
    int baseHealth, baseMovespeed; 
    float baseMagicCooldownMod;
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

    void ResetStats()
	{
        health = baseHealth;
        movespeed = baseMovespeed;
        magicCooldownMod = baseMagicCooldownMod;
        Player.instance.GetBuild().GetSpell().ResetSpellValues();
	}
    public bool ApplyBuild()
	{
        try //attempt to apply the effects of all the items to the stats of the player
        {
            Build playerBuild = Player.instance.GetBuild();
            Armour armour = playerBuild.GetArmour();
            Artifact artifact = playerBuild.GetArtifact();
            Weapon weapon = playerBuild.GetWeapon();
            ResetStats();
            health += armour.HealthMod() + artifact.HealthMod() + weapon.HealthMod();
            movespeed += armour.MovespeedMod() + artifact.MovespeedMod();
            magicCooldownMod += artifact.MagicCooldownMod();
            playerBuild.GetSpell().ModifyCooldownMax(magicCooldownMod);
            PlayerUI.instance.UpdatePlayerHealthText();
            Debug.Log("health: " + health + " Movespeed: " + movespeed + " Spell Cooldown: " + playerBuild.GetSpell().GetCooldown() + " Spell: " + playerBuild.GetSpell().GetType());
            return true;
        }
        catch
		{
            return false;
		}
	}
}
