using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : BaseEntity
{
    public BaseEnemy(float sp = 3f, int dm = 25) : base(sp, 6, 0.3f, 100, dm) { 
        isGrounded = false;
    }

    public Vector2 WalkTo(Vector2 pos, Vector2 toWalkTo)
    {
        return Vector2.ClampMagnitude(toWalkTo - pos, 1f) * distToCover;
    }
}
