using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState
{
    Idle,
    LeftRun,
    RightRun
};

public class pctrl : MonoBehaviour
{
    Rigidbody2D rb;
    BaseEntity b_entity;
    rcast rc;

    PlayerState pState;
    Animator anim;

    void Start()
    {
        b_entity = new BaseEntity();
        rc = new rcast();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
            rc.shoot(GetComponent<Transform>(), Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    void FixedUpdate()
    {
        GetComponent<Transform>().position = HandleMovement(transform);
        HandleJump(rb);

        if (pState == PlayerState.Idle)
            anim.SetBool("IsRunning", false);
        else
            anim.SetBool("IsRunning", true);

    }

    public Vector2 HandleMovement(Transform pos)
    {
        Vector2 _pos = pos.position;

        if (Input.GetKey(KeyCode.A))
        {
            _pos.x = b_entity.Move("Left", pos.position.x);
            pState = PlayerState.LeftRun;
        }
        else pState = PlayerState.Idle;

        if (Input.GetKey(KeyCode.D)) {
            _pos.x = b_entity.Move("Right", pos.position.x);
            pState = PlayerState.RightRun;
        }
        else pState = PlayerState.Idle;
        
        return _pos;

    }

    public void HandleJump(Rigidbody2D _rb)
    {
        if (Input.GetKey(KeyCode.Space))
            b_entity.Jump(_rb);
    }

    void OnCollisionStay2D(Collision2D collision)
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
