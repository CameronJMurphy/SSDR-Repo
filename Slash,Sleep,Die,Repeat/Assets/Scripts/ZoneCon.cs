using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCon : MonoBehaviour
{
    public static ZoneCon instance;
    public List<Zone> zones;
    public Zone activeZone;
    // Start is called before the first frame update
    void Start()
    {
        zones = new List<Zone>(GetComponentsInChildren<Zone>());
        if(instance == null)
		{
            instance = this;
		}
		else
		{
            Destroy(this);
		}
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var z in zones)
		{
            if(z.active)
			{
                activeZone = z;
			}
		}
    }
}
