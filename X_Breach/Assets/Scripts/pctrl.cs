using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pctrl : MonoBehaviour
{
    Rigidbody2D rb;

    public float distToCover = 0.08f, jumpForce = 6f, decFactor = 0.3f;
    bool isGrounded = false;
    public float move = 0;
        private Animator anim;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        anim = GetComponent<Animator>();  
        HandleMovement(transform, distToCover);
        Jump(jumpForce);
        if (move == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }




        


    }

    void HandleMovement(Transform pos, float ds)
    {
        Vector2 _pos = pos.position;


        if (Input.GetKey(KeyCode.A))
            if (isGrounded)
            {
                move = -1;
                _pos.x -= ds;
            }
            else _pos.x -= ds * decFactor;

        if (Input.GetKey(KeyCode.D))
            if (isGrounded) {
                move = 1;
                _pos.x += ds; 
            
            
            }
            else _pos.x += ds * decFactor;


        GetComponent<Transform>().position = _pos;
        move = 0;
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
