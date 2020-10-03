using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EndPoints {
    public Vector2 lEnd, rEnd;

    public EndPoints(Vector2 l, Vector2 r)
    {
        lEnd = l;
        rEnd = r;
    }
}

enum EnemyState
{
    Idle,
    Walking,
    OnAlert,
    Attacking
};

public class BaseEnemy : BaseEntity
{
    EnemyState eState = EnemyState.Idle;

    float newX = 0f;
    int dir, currentDir;

    public BaseEnemy(float sp = 0.1f, int dm = 25) : base(sp, 6, 0.3f, 100, dm) { 
        isGrounded = false;
        
    }

    //Broken pathfinding
    public Vector2 Pathfinding(Vector2 pos, EndPoints boundaries)
    {
        dir = (int)Mathf.Round(Random.Range(0f, 1f));

        if (eState != EnemyState.Walking)
            currentDir = dir;

        Debug.Log(newX + " " + boundaries.lEnd.x + " " + boundaries.rEnd.x);

        if (pos.x > boundaries.lEnd.x && pos.x < boundaries.rEnd.x 
            && pos.y >= boundaries.lEnd.y)
        {
            newX = Walk(pos, currentDir);
            Debug.Log(newX);
        }
        else newX += Halt(currentDir);
        
        return new Vector2(newX, pos.y);
    }

    float Walk(Vector2 pos, int dir)
    {
        eState = EnemyState.Walking;

        if(dir == 1)
        {
            return Move("Left", pos.x);
        } 
        else
        {
            return Move("Right", pos.x);
        }
    }

    float Halt(int dir)
    {
        eState = EnemyState.Idle;
        if (dir == 1)
        {
            //currentDir = 0;
            return -.8f;
        }
        else 
        {
            //currentDir = 1;
            return .8f;
        }
    }
}
