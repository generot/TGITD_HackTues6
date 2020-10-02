using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pctrl : MonoBehaviour
{
    Rigidbody2D rb;
    BaseEntity b_entity;

    void Start()
    {
        b_entity = new BaseEntity();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        GetComponent<Transform>().position = b_entity.HandleMovement(transform);
        b_entity.Jump(rb);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            b_entity.isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            b_entity.isGrounded = false;
    }
}
