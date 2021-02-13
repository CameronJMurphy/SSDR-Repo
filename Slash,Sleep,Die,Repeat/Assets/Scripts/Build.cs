using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    Weapon weapon;
    Armour armour;
    Magic spell;
    Artifact artifact;

   //setters
    public void SetWeapon(Weapon w) { weapon = w; Debug.Log(weapon.GetType()); }
    public void SetArmour(Armour a) { armour = a; Debug.Log(armour.GetType()); }
    public void SetSpell(Magic m) { spell = m; Debug.Log(spell.GetType()); }
    public void SetArtifact(Artifact a) { artifact = a; Debug.Log(artifact.GetType()); }
    //getters
    public Weapon GetWeapon() { return weapon; }
    public Armour GetArmour() { return armour; }
    public Magic GetSpell() { return spell; }
    public Artifact GetArtifact() { return artifact; }
}

