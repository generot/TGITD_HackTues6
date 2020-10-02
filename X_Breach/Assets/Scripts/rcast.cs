using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast : MonoBehaviour
{
    public int units = 7;
    public void shoot(Transform transform, Vector3 mousepos)
    {
<<<<<<< HEAD
        Vector2 dir = mousepos-transform.position;
        Vector2 normalize = Vector2.ClampMagnitude(dir, 0.1f);
        RaycastHit2D col = Physics2D.Raycast(transform.position, normalize);
        if (col)
=======

        Vector2 dir = mousepos - transform.position;
        Vector2 normalize = Vector2.ClampMagnitude(dir, 0.1f);
        RaycastHit2D col = Physics2D.Raycast(transform.position, normalize);
        if (col)
        {

>>>>>>> 0df9285508f5e90abab97a1d35ca6610a2a6ddef
            Debug.Log(col.transform.name);
        }
    }
}
