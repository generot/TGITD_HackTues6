using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Transform point;
    public float attackRange;
    public LayerMask hostile;
    public int dmg;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Melee();
        }
    }
    void Melee()
    {
        Collider2D[] entity_array = Physics2D.OverlapCircleAll(point.position, attackRange, hostile);
        foreach(Collider2D Enemy in entity_array)
        {
            Debug.Log("we hit " + Enemy);

            Enemy.gameObject.GetComponent<Enemy>().b_entity.TakeDamage(dmg);
            Debug.Log(Enemy.gameObject.GetComponent<Enemy>().b_entity.health);

            if (Enemy.gameObject.GetComponent<Enemy>().b_entity.health <= 0)
            {
                Destroy(Enemy.gameObject, 0);
            }
        }
    }
}
