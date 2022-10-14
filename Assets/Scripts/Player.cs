using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int life;

    private bool isGrounded;
    private Rigidbody2D rig;
    private Vector2 direction;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        rig.velocity = new Vector2(direction.x * speed, rig.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void Death()
    {

    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }
}
