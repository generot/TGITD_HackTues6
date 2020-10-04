using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast : MonoBehaviour
{
    public float units = 7f;
    public int damage;
    public Transform sPoint;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine (shoot(sPoint, Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }
    public IEnumerator shoot(Transform transform, Vector3 mousePos)
    {
        Vector2 dir = mousePos - transform.position;
        mousePos = Vector2.ClampMagnitude(dir, 1f);

        RaycastHit2D enemyInf = Physics2D.Raycast(transform.position, mousePos, units);
        if (enemyInf) {
            Enemy hostile = enemyInf.transform.GetComponent<Enemy>();
            if (hostile != null)
            {
                hostile.gameObject.GetComponent<Enemy>().b_entity.TakeDamage(damage);
                Debug.Log(hostile.gameObject.GetComponent<Enemy>().b_entity.health);
                yield return 0; //for now because its a coroutine, but later because it will be an animation :)

                if (hostile.gameObject.GetComponent<Enemy>().b_entity.health <= 0)
                {
                    yield return 0; //same as ^
                    Destroy(hostile.gameObject, 0);
                }
            }
        }
    }
}
