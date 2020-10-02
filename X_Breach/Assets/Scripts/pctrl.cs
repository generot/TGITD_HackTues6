using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pctrl : MonoBehaviour
{
    Rigidbody2D rb;
    BaseEntity b_entity;
    rcast rc;
    void Start()
    {
        b_entity = new BaseEntity();
        rc = new rcast();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rc.shoot(transform, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void FixedUpdate()
    {
        GetComponent<Transform>().position = HandleMovement(transform);
        HandleJump(rb);
    }

    public Vector2 HandleMovement(Transform pos)
    {
        Vector2 _pos = pos.position;

        if (Input.GetKey(KeyCode.A))
            _pos.x = b_entity.Move("Left", pos.position.x);

        if (Input.GetKey(KeyCode.D))
            _pos.x = b_entity.Move("Right", pos.position.x);

        return _pos;
    }

    public void HandleJump(Rigidbody2D _rb)
    {
        if (Input.GetKey(KeyCode.Space))
            b_entity.Jump(_rb);
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
