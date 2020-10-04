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
           StartCoroutine (Melee());
        }
    }
    IEnumerator Melee()
    {
        Collider2D[] entity_array = Physics2D.OverlapCircleAll(point.position, attackRange, hostile);
        foreach(Collider2D Enemy in entity_array)
        {
            Debug.Log("we hit " + Enemy);
<<<<<<< HEAD
            Enemy.gameObject.GetComponent<LRankGuard>().b_enemy.TakeDamage(dmg);
            yield return 0;
            Debug.Log(Enemy.gameObject.GetComponent<LRankGuard>().b_enemy.health);
            if (Enemy.gameObject.GetComponent<LRankGuard>().b_enemy.health <= 0)
=======
            Enemy.gameObject.GetComponent<Enemy>().b_entity.TakeDamage(dmg);
            Debug.Log(Enemy.gameObject.GetComponent<Enemy>().b_entity.health);
            if (Enemy.gameObject.GetComponent<Enemy>().b_entity.health <= 0)
>>>>>>> 21fcf7188371e3a0c295753ddd3e2bcc4e2c4547
            {
                Destroy(Enemy.gameObject, 0);
            }
        }
    }
}
