﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateToMouse : MonoBehaviour
{
    Vector3 mousePos;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Player.instance.PlayerToMouse();
        angle = AngleBetweenPoints(transform.position, mousePos);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
