using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public BaseEnemy b_enemy;
    public BaseEntity b_entity;

    public Transform player;

    Rigidbody2D rb;

    void Start()
    {
        b_entity = new BaseEntity(b_enemy.sp, 0f, 0.3f, b_enemy.health, b_enemy.dmg);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 distVec = player.position - transform.position;
        float distSq = distVec.x * distVec.x + distVec.y * distVec.y;

        if (distSq > 16f)
            rb.velocity = WalkTo(transform.position, player.position);
    }

    public Vector2 WalkTo(Vector2 pos, Vector2 toWalkTo)
    {
        return Vector2.ClampMagnitude(toWalkTo - pos, 1f) * b_entity.distToCover;
    }
}
