using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRankGuard : MonoBehaviour
{
<<<<<<< HEAD
    BaseEnemy b_enemy;

    public Transform Player;
=======
    public BaseEnemy b_enemy;
>>>>>>> c2a6838eb1a77520f1defb8693690a9faa0cca06
    public Transform platform;

    Rigidbody2D rb;

    void Start()
    {
        b_enemy = new BaseEnemy(); 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
<<<<<<< HEAD
        Vector2 distVec = Player.position - transform.position;
        float distSq = distVec.x * distVec.x + distVec.y * distVec.y;

        if (distSq > 16f)
            rb.velocity = b_enemy.WalkTo(transform.position, Player.position);
=======
//if(b_enemy!=null)
        //transform.localPosition = b_enemy.Pathfinding(transform.localPosition, bndry);
>>>>>>> c2a6838eb1a77520f1defb8693690a9faa0cca06
    }
}
