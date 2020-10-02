using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast : MonoBehaviour
{
    
    public Transform player;
    public int units = 30;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shoot();
        }
     
    }
    void shoot()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D col = Physics2D.Raycast(dir, new Vector2(dir.x + units, dir.y));
        if (col) {
            Debug.Log(col.transform.name);
                }
    }
}
