using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRankGuard : MonoBehaviour
{
    public BaseEnemy b_enemy;
    public Transform platform;

    Rigidbody2D rb;

    void Start()
    {
        b_enemy = new BaseEnemy(); 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 distVec = Player.position - transform.position;
        float distSq = distVec.x * distVec.x + distVec.y * distVec.y;

        if (distSq > 16f)
            rb.velocity = b_enemy.WalkTo(transform.position, Player.position);
    }
}
