using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast : MonoBehaviour
{
    public float units = 7f;
    public int dmg;
    public Transform sPoint;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shoot(sPoint, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
    public void shoot(Transform transform, Vector3 mousePos)
    {
        Vector2 dir = mousePos-transform.position;
        mousePos = Vector2.ClampMagnitude(dir, 1f);

        RaycastHit2D enemyInf = Physics2D.Raycast(transform.position, mousePos, units);
        if (enemyInf) {
            LRankGuard hostile = enemyInf.transform.GetComponent<LRankGuard>();
            if (hostile != null)
            {
                hostile.gameObject.GetComponent<LRankGuard>().b_enemy.TakeDamage(dmg);
                Debug.Log(hostile.gameObject.GetComponent<LRankGuard>().b_enemy.health);
                if (hostile.gameObject.GetComponent<LRankGuard>().b_enemy.health <= 0)
                {
                    Destroy(hostile.gameObject, 1);
                }
            }
        }
    }
}
