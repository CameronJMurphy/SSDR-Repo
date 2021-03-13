using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArmour : MonoBehaviour
{
    Player player;
    [SerializeField] Color clothColour;
    [SerializeField] Color trollColour;
    [SerializeField] Color scaleColour;

    Animator playerAni;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;

        playerAni = player.GetComponent<Animator>();
    }

    public void Spawn()
    {

        player.GetComponent<Animator>().Equals(null);
        switch (player.GetBuild().GetArmour().GetType())
        { 
            
            case Armour.Type.robe:
                player.GetComponent<SpriteRenderer>().color = clothColour;
                break;
            case Armour.Type.trollHide:
                player.GetComponent<SpriteRenderer>().color = trollColour;
                break;
            case Armour.Type.dragonScale:
                player.GetComponent<SpriteRenderer>().color = scaleColour;
                break;
        }
        player.GetComponent<Animator>().Equals(playerAni);


    }
}
