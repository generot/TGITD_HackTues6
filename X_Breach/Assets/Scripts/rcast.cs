using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast
{
    public float units = 7f;
    public void shoot(Transform transform, Vector3 mousePos)
    {
<<<<<<< HEAD
        Vector2 dir = mousePos-transform.position;
       mousePos = Vector2.ClampMagnitude(dir, 1f);
        RaycastHit2D col = Physics2D.Raycast(transform.position, mousePos, units);
        if (col) {
=======
        Vector2 dir = mousepos - transform.position;
        Vector2 normalize = Vector2.ClampMagnitude(dir, 0.1f);
        RaycastHit2D col = Physics2D.Raycast(transform.position, normalize);
        if (col)
        {
<<<<<<< HEAD

=======
>>>>>>> 997ce01bd66e176892ae03bbee7bf13e3427cee8
>>>>>>> a1561a24aeb7268891c873163d2d28e80e495af9
            Debug.Log(col.transform.name);
        }
    }
}
