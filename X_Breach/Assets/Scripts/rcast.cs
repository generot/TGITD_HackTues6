﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast
{
    public int units = 7;
    public void shoot(Transform transform, Vector3 mousepos)
    {
        Vector2 dir = mousepos-transform.position;
        Vector2 normalize = Vector2.ClampMagnitude(dir, 0.1f);
        RaycastHit2D col = Physics2D.Raycast(transform.position, normalize);
        if (col)
            Debug.Log(col.transform.name);
    }
}
