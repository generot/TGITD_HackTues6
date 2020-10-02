using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pctrl : MonoBehaviour
{
    Rigidbody2D rb;

    public float distToCover = 0.08f, jumpForce = 6f, decFactor = 0.3f;
    bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        HandleMovement(transform, distToCover);
        Jump(jumpForce);
    }

    void HandleMovement(Transform pos, float ds)
    {
        Vector2 _pos = pos.position;

        if (Input.GetKey(KeyCode.A))
            if (isGrounded) _pos.x -= ds; 
            else _pos.x -= ds * decFactor;

        if (Input.GetKey(KeyCode.D))
            if (isGrounded) _pos.x += ds; 
            else _pos.x += ds * decFactor;

        GetComponent<Transform>().position = _pos;
    }

    void Jump(float ds)
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            rb.velocity = Vector2.up * ds; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = false;
    }
}
