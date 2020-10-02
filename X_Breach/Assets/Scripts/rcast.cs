using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast
{
    public int units = 7;
    public void shoot(Transform transform, Vector3 mousepos)
    {
<<<<<<< HEAD
        if (Input.GetMouseButton(0))
            shoot();
     
    }
    void shoot()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D col = Physics2D.Raycast(dir, new Vector2(dir.x + units, dir.y));

        if (col)
=======
        Vector2 dir = mousepos-transform.position;
        Vector2 normalize = Vector2.ClampMagnitude(dir, 0.1f);
        RaycastHit2D col = Physics2D.Raycast(transform.position, normalize);
        if (col) {
>>>>>>> 79b0abf3c21b32fae92b5643243a8a584550d3db
            Debug.Log(col.transform.name);
    }
}
