using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity
{ 
    float distToCover, jumpForce, decFactor;

    //Jumping is handled externally
    public bool isGrounded;

    public BaseEntity(float ds = 0.1f, 
        float jmpForce = 6f, float dcFac = 0.3f)
    {
        distToCover = ds;
        jumpForce = jmpForce;
        decFactor = dcFac;

        isGrounded = false;
    }

    public float Move(string dir, float origin)
    {
        if (dir == "Left")
        {
            if (isGrounded)
                origin -= distToCover;
            else
                origin -= distToCover * decFactor;
        } 
        else if (dir == "Right") 
        {
            if (isGrounded)
                origin += distToCover;
            else
                origin += distToCover * decFactor;
        }

        return origin;
    }

    public void Jump(Rigidbody2D _rb)
    {
        if (isGrounded)
            _rb.velocity = Vector2.up * jumpForce;
    }
}
