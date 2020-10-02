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

    public Vector2 HandleMovement(Transform pos)
    {
        Vector2 _pos = pos.position;

        if (Input.GetKey(KeyCode.A))
            if (isGrounded) 
                _pos.x -= distToCover;
            else 
                _pos.x -= distToCover * decFactor;

        if (Input.GetKey(KeyCode.D))
            if (isGrounded) 
                _pos.x += distToCover;
            else 
                _pos.x += distToCover * decFactor;

        return _pos;
    }

    public void Jump(Rigidbody2D _rb)
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            _rb.velocity = Vector2.up * jumpForce;
    }
}
