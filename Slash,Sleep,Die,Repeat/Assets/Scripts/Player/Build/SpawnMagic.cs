using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMagic : MonoBehaviour
{
    Player player;
    [SerializeField] SpriteRenderer fireball;
    [SerializeField] SpriteRenderer teleport;
    [SerializeField] SpriteRenderer shield;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
    }

    public void Spawn()
    {
        switch (player.GetBuild().GetSpell().GetType())
        {

            case Magic.Type.fireball:
                fireball.gameObject.SetActive(true);
                teleport.gameObject.SetActive(false);
                shield.gameObject.SetActive(false);

                break;
            case Magic.Type.teleport:
                fireball.gameObject.SetActive(false);
                teleport.gameObject.SetActive(true);
                shield.gameObject.SetActive(false);

                break;
            case Magic.Type.shield:
                fireball.gameObject.SetActive(false);
                teleport.gameObject.SetActive(false);
                shield.gameObject.SetActive(true);
                break;
        }



    }
}
