using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//This just pops up text when the player walks on an item in the starting room to show them what it is and what it does
public class StartRoomUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI weaponText;
    [SerializeField] TextMeshProUGUI armourText;
    [SerializeField] TextMeshProUGUI artifactText;
    [SerializeField] TextMeshProUGUI magicText;
    [SerializeField] TextMeshProUGUI tutorialText;

    public void DisplayWeaponText(bool answer)
	{
        weaponText.gameObject.SetActive(answer);
        weaponText.text = Player.instance.GetBuild().GetWeapon().GetType().ToString() + ": +" + Player.instance.GetBuild().GetWeapon().HealthMod() + " hp";
    }

    public void DisplayArmourText(bool answer)
	{
        armourText.gameObject.SetActive(answer);
        armourText.text = Player.instance.GetBuild().GetArmour().GetType().ToString() +
                          ": +" + Player.instance.GetBuild().GetArmour().HealthMod() + " hp" +
                          " & +" + Player.instance.GetBuild().GetArmour().MovespeedMod() + " ms";
                            
    }

    public void DisplayArtifactText(bool answer)
	{
        artifactText.gameObject.SetActive(answer);
        artifactText.text = Player.instance.GetBuild().GetArtifact().GetType().ToString() +
                            ": +" + Player.instance.GetBuild().GetArtifact().HealthMod() + " hp" +
                            " & +" + Player.instance.GetBuild().GetArtifact().MovespeedMod() + " ms" +
                            " & " + Player.instance.GetBuild().GetArtifact().MagicCooldownMod() + " cd mod";

    }

    public void DisplayMagicText(bool answer)
	{
        magicText.gameObject.SetActive(answer);
        magicText.text = Player.instance.GetBuild().GetSpell().GetType().ToString() +
            ": " + Player.instance.GetBuild().GetSpell().GetCooldown() + " cd";
    }

    public void DisplayTutorialText(bool answer)
	{
        tutorialText.gameObject.SetActive(answer);
    }
}
