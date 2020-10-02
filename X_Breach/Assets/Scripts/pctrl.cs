using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pctrl : MonoBehaviour
{
    Rigidbody2D rb;
<<<<<<< HEAD

    public float distToCover = 0.08f, jumpForce = 6f, decFactor = 0.3f;
    bool isGrounded = false;
    public float move = 0;
        private Animator anim;
  
=======
    BaseEntity b_entity;
    rcast rc;
>>>>>>> ef838f5110031873d671200f24cbe2bc95f35043
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
<<<<<<< HEAD
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




        


=======
        GetComponent<Transform>().position = HandleMovement(transform);
        HandleJump(rb);
>>>>>>> ef838f5110031873d671200f24cbe2bc95f35043
    }

    public Vector2 HandleMovement(Transform pos)
    {
        Vector2 _pos = pos.position;


        if (Input.GetKey(KeyCode.A))
<<<<<<< HEAD
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
=======
            _pos.x = b_entity.Move("Left", pos.position.x);

        if (Input.GetKey(KeyCode.D))
            _pos.x = b_entity.Move("Right", pos.position.x);

        return _pos;
>>>>>>> ef838f5110031873d671200f24cbe2bc95f35043
    }

    public void HandleJump(Rigidbody2D _rb)
    {
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            rb.velocity = Vector2.up * ds; 
=======
        if (Input.GetKey(KeyCode.Space))
            b_entity.Jump(_rb);
>>>>>>> ef838f5110031873d671200f24cbe2bc95f35043
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
