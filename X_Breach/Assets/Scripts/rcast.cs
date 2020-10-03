using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast
{
    public float units = 7f;
    public void shoot(Transform transform, Vector3 mousePos)
    {
        Vector2 dir = mousePos-transform.position;
        mousePos = Vector2.ClampMagnitude(dir, 1f);

        RaycastHit2D col = Physics2D.Raycast(transform.position, mousePos, units);
        if (col) {
            Debug.Log(col.transform.name);
        }
    }
}
