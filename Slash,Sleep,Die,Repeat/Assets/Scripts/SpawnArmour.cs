using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArmour : MonoBehaviour
{
    Player player;
    [SerializeField] Color clothColour;
    [SerializeField] Color scaleColour;
    [SerializeField] Color plateColour;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
    }

    public void Spawn()
    {
        switch (player.GetBuild().GetArmour().GetType())
        {
            
            case Armour.Type.cloth:
                player.GetComponent<SpriteRenderer>().color = clothColour;
                break;
            case Armour.Type.scalemail:
                player.GetComponent<SpriteRenderer>().color = scaleColour;
                break;
            case Armour.Type.platemail:
                player.GetComponent<SpriteRenderer>().color = plateColour;
                break;
        }
        
        

	}
}
