using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArtifact : MonoBehaviour
{
    Player player;
    [SerializeField] SpriteRenderer sage;
    [SerializeField] SpriteRenderer prayingMantis;
    [SerializeField] SpriteRenderer giant;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
    }

    public void Spawn()
    {
        switch (player.GetBuild().GetArtifact().GetType())
        {

            case Artifact.Type.sage:
                sage.gameObject.SetActive(true);
                prayingMantis.gameObject.SetActive(false);
                giant.gameObject.SetActive(false);

                break;
            case Artifact.Type.prayerMantis:
                prayingMantis.gameObject.SetActive(true);
                sage.gameObject.SetActive(false);
                giant.gameObject.SetActive(false);

                break;
            case Artifact.Type.giant:
                giant.gameObject.SetActive(true);
                prayingMantis.gameObject.SetActive(false);
                sage.gameObject.SetActive(false);
                break;
        }



    }
}
